// --- Modal ---
const modal = document.getElementById('modalCriar');
const btnNovo = document.getElementById('btnNovo');
const btnAbrirForm = document.getElementById('btnAbrirForm');
const btnCancelar = document.getElementById('btnCancelar');

btnNovo.addEventListener('click', () => modal.style.display = 'flex');
btnAbrirForm.addEventListener('click', () => modal.style.display = 'flex');
btnCancelar.addEventListener('click', () => modal.style.display = 'none');

// --- Formulário ---
const formCriar = modal.querySelector('form');

formCriar.addEventListener('submit', async (e) => {
    e.preventDefault(); // impede envio padrão

    const novoSuporte = {
        assunto: document.getElementById('Assunto').value,
        categoria: document.getElementById('Categoria').value,
        descricao: document.getElementById('Descricao').value
    };

    try {
        const response = await fetch('https://localhost:44360/api/Suporte', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(novoSuporte)
        });

        if (!response.ok) throw new Error('Erro ao criar o suporte: ' + response.status);

        const criado = await response.json();
        console.log('Suporte criado:', criado);

        // Limpar formulário e fechar modal
        formCriar.reset();
        modal.style.display = 'none';

        // Atualizar lista
        carregarTickets();

    } catch (erro) {
        console.error(erro);
        alert('Não foi possível criar o ticket.');
    }
});

// --- Carregar tickets ---
async function carregarTickets() {
    const ticketsContainer = document.querySelector('.tickets');
    const statusMap = {
        0: "Aberta",
        1: "Andamento",
        2: "Finalizada"
    };


    try {
        const response = await fetch('https://localhost:44360/api/Suporte');
        if (!response.ok) throw new Error('Erro ao buscar tickets');

        const tickets = await response.json();

        if (!tickets || tickets.length === 0) {
            ticketsContainer.innerHTML = `
                        <div class="empty">
                            <div style="font-size:20px;margin-bottom:8px">Nenhum pedido criado</div>
                            <div class="muted">Clique em "Criar novo pedido" para abrir um chamado ao time de suporte.</div>
                        </div>
                    `;
            return;
        }

        ticketsContainer.innerHTML = '';


        const divHeader = document.createElement('div');
        divHeader.classList.add('ticket');
        divHeader.innerHTML += `
                <strong>ID - Nome Tarefa</strong>
                <div>Descrição</div>
                <div>Status</div>
                <div>Mais detalhes</div>
        `;
        ticketsContainer.appendChild(divHeader);


        tickets.forEach(ticket => {
            const div = document.createElement('div');
            div.classList.add('ticket');
            div.innerHTML = `
                        <strong>#${ticket.id} - ${ticket.nome}</strong>
                        <div>${ticket.descricao}</div>
                        <div>${statusMap[ticket.status]}</div>
                        <a class="btn btn-outline-light btn-sm">Detalhes</a>
                    `;
            ticketsContainer.appendChild(div);
        });

    } catch (erro) {
        console.error(erro);
        ticketsContainer.innerHTML = `<div class="muted">Erro ao carregar tickets.</div>`;
    }
}

// --- Inicializar ---
document.addEventListener('DOMContentLoaded', () => {
    carregarTickets();
});