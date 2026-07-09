import { useEffect, useState } from 'react';
import api from './services/api';
import { PersonForm } from './components/PersonForm';
import { TransactionForm } from './components/TransactionForm';

interface PersonTotal {
    personName: string;
    totalIncome: number;
    totalExpense: number;
    netBalance: number;
}

interface DashboardData {
    people: PersonTotal[];
    grandTotalIncome: number;
    grandTotalExpense: number;
    grandNetBalance: number;
}

function App() {
   
    const [dashboard, setDashboard] = useState<DashboardData | null>(null);

    

    const carregarDashboard = () => {
        api.get('/Dashboard')
            .then(response => {
                setDashboard(response.data); 
            })
            .catch(error => {
                console.error("Erro ao buscar dados:", error);
            });
    };
    useEffect(() => {
        carregarDashboard();
    }, []);

    return (
        <div style={{ padding: '20px', fontFamily: 'Arial', maxWidth: '800px', margin: '0 auto' }}>
            <h1>Painel de Controle de Gastos</h1>

            {<PersonForm onPersonAdded={carregarDashboard} />}
            {<TransactionForm onTransactionAdded={carregarDashboard} /> }
            {dashboard ? (
                <>
                    <table style={{ width: '100%', borderCollapse: 'collapse', marginBottom: '20px' }}>
                        <thead>
                            <tr style={{ backgroundColor: '#f4f4f4', textAlign: 'left' }}>
                                <th style={{ padding: '10px', border: '1px solid #ddd' }}>Pessoa</th>
                                <th style={{ padding: '10px', border: '1px solid #ddd' }}>Receitas</th>
                                <th style={{ padding: '10px', border: '1px solid #ddd' }}>Despesas</th>
                                <th style={{ padding: '10px', border: '1px solid #ddd' }}>Saldo Líquido</th>
                            </tr>
                        </thead>
                        <tbody>
                            {dashboard.people.length === 0 ? (
                                <tr>
                                    <td colSpan={4} style={{ padding: '10px', textAlign: 'center', border: '1px solid #ddd' }}>
                                        Nenhuma pessoa cadastrada no banco de dados.
                                    </td>
                                </tr>
                            ) : (
                                dashboard.people.map((person, index) => (
                                    <tr key={index}>
                                        <td style={{ padding: '10px', border: '1px solid #ddd' }}>{person.personName}</td>
                                        <td style={{ padding: '10px', border: '1px solid #ddd', color: 'green' }}>
                                            R$ {person.totalIncome.toFixed(2)}
                                        </td>
                                        <td style={{ padding: '10px', border: '1px solid #ddd', color: 'red' }}>
                                            R$ {person.totalExpense.toFixed(2)}
                                        </td>
                                        <td style={{
                                            padding: '10px',
                                            border: '1px solid #ddd',
                                            fontWeight: 'bold',
                                            color: person.netBalance >= 0 ? 'green' : 'red'
                                        }}>
                                            R$ {person.netBalance.toFixed(2)}
                                        </td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>


                    <div style={{ backgroundColor: '#e9ecef', padding: '15px', borderRadius: '8px' }}>
                        <h3>Resumo Geral da Casa</h3>
                        <p><strong>Total de Receitas:</strong> R$ {dashboard.grandTotalIncome.toFixed(2)}</p>
                        <p><strong>Total de Despesas:</strong> R$ {dashboard.grandTotalExpense.toFixed(2)}</p>
                        <p><strong>Saldo Geral:</strong> R$ {dashboard.grandNetBalance.toFixed(2)}</p>
                    </div>
                </>
            ) : (
                <p>Carregando dados do servidor...</p>
            )}
        </div>
    );
}

export default App;