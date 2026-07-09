import { useState } from 'react';
import api from '../services/api';


interface PersonFormProps {
    onPersonAdded: () => void;
}

export function PersonForm({ onPersonAdded }: PersonFormProps) {
    const [name, setName] = useState('');
    const [age, setAge] = useState<number | ''>('');

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault(); 

        api.post('/People', { name: name, age: Number(age) })
            .then(() => {
                alert('Pessoa cadastrada com sucesso!');
                setName(''); 
                setAge('');  
                onPersonAdded();
            })
            .catch(error => {
                console.error("Erro ao cadastrar pessoa:", error);
                alert('Erro ao cadastrar. Verifique o console.');
            });
    };

    return (
        <form
            onSubmit={handleSubmit}
            style={{ marginBottom: '20px', padding: '15px', backgroundColor: '#e9ecef', borderRadius: '8px' }}
        >
            <h3>👤 Cadastrar Nova Pessoa</h3>
            <input
                type="text"
                placeholder="Nome"
                value={name}
                onChange={e => setName(e.target.value)}
                required
                style={{ marginRight: '10px', padding: '8px', borderRadius: '4px', border: '1px solid #ccc' }}
            />
            <input
                type="number"
                placeholder="Idade"
                value={age}
                onChange={e => setAge(e.target.value === '' ? '' : Number(e.target.value))}
                required
                style={{ marginRight: '10px', padding: '8px', borderRadius: '4px', border: '1px solid #ccc', width: '80px' }}
            />
            <button
                type="submit"
                style={{ padding: '8px 15px', backgroundColor: '#007bff', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' }}
            >
                Salvar
            </button>
        </form>
    );
}