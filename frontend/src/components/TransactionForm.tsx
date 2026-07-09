import { useState } from 'react';
import api from '../services/api';


interface TransactionFormProps {
    onTransactionAdded: () => void;
}

export function TransactionForm({ onTransactionAdded }: TransactionFormProps) {
    const [description, setDescription] = useState('');
    const [amount, setAmount] = useState<number | ''>('');
    const [type, setType] = useState<number>(0); // 0 = Income, 1 = Expense
    const [personId, setPersonId] = useState<number | ''>('');

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();

        const payload = {
            description,
            amount: Number(amount),
            type: type,
            personId: Number(personId)
        };

        api.post('/Transactions', payload)
            .then(() => {
                alert('Transação lançada com sucesso!');
                setDescription('');
                setAmount('');
                setPersonId('');
                onTransactionAdded(); 
            })
            .catch(error => {
                
                if (error.response && error.response.status === 400) {
                    alert(`REJEITADO: ${error.response.data}`);
                } else {
                    alert('Erro ao lançar transação. Verifique se o ID da pessoa existe.');
                }
            });
    };

    return (
        <form
            onSubmit={handleSubmit}
            style={{ marginBottom: '20px', padding: '15px', backgroundColor: '#e9ecef', borderRadius: '8px' }}
        >
            <h3>💸 Lançar Nova Transação</h3>
            <div style={{ display: 'flex', gap: '10px', flexWrap: 'wrap' }}>
                <input
                    type="text"
                    placeholder="Descrição (ex: Conta de Luz)"
                    value={description}
                    onChange={e => setDescription(e.target.value)}
                    required
                    style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc', flex: 1 }}
                />
                <input
                    type="number"
                    placeholder="Valor"
                    value={amount}
                    onChange={e => setAmount(e.target.value === '' ? '' : Number(e.target.value))}
                    required
                    style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc', width: '100px' }}
                />
                <select
                    value={type}
                    onChange={e => setType(Number(e.target.value))}
                    style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc' }}
                >
                    <option value={0}>Receita (Entrada)</option>
                    <option value={1}>Despesa (Saída)</option>
                </select>
                <input
                    type="number"
                    placeholder="ID da Pessoa"
                    value={personId}
                    onChange={e => setPersonId(e.target.value === '' ? '' : Number(e.target.value))}
                    required
                    style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc', width: '120px' }}
                />
                <button
                    type="submit"
                    style={{ padding: '8px 15px', backgroundColor: '#28a745', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' }}
                >
                    Lançar
                </button>
            </div>
        </form>
    );
}