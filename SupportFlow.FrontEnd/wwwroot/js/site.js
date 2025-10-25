// --- Modal ---
const modal = document.getElementById('modalCriar');
const btnNovo = document.getElementById('btnNovo');
const btnAbrirForm = document.getElementById('btnAbrirForm');
const btnCancelar = document.getElementById('btnCancelar');

if (btnNovo) btnNovo.addEventListener('click', () => modal.style.display = 'flex');
if (btnAbrirForm) btnAbrirForm.addEventListener('click', () => modal.style.display = 'flex');
if (btnCancelar) btnCancelar.addEventListener('click', () => modal.style.display = 'none');

// --- Formulário (EM PRODUÇÃO)---
const formCriar = modal?.querySelector('form');

if (formCriar) {
    formCriar.addEventListener('submit', async (e) => {
        e.preventDefault(); // impede envio padrão

        const novoSuporte = {
            assunto: document.getElementById('Assunto').value,
            categoria: document.getElementById('Categoria').value,
            descricao: document.getElementById('Descricao').value
        };

        try {
            const token = localStorage.getItem('token') || sessionStorage.getItem('token');

            const response = await fetch('https://localhost:44360/api/Suporte', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
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
}

// --- Carregar tickets --- 
async function carregarTickets() {
    const ticketsContainer = document.querySelector('.tickets');
    if (!ticketsContainer) return;

    const statusMap = {
        0: "Aberta",
        1: "Andamento",
        2: "Finalizada"
    };

    try {
        const token = localStorage.getItem('token') || sessionStorage.getItem('token');

        const response = await fetch('https://localhost:44360/api/Auth/tickets', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });

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
        divHeader.innerHTML = `
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
                <div>${statusMap[ticket.status] || "Desconhecido"}</div>
                <a class="btn btn-outline-light btn-sm">Detalhes</a>
            `;
            ticketsContainer.appendChild(div);
        });

    } catch (erro) {
        console.error(erro);
        ticketsContainer.innerHTML = `<div class="muted">Erro ao carregar tickets.</div>`;
    }
}

// --- LOGIN ---
async function configurarLogin() {
    const btnEntrar = document.getElementById('entrar');
    if (!btnEntrar) return;

    btnEntrar.addEventListener('click', async (e) => {
        e.preventDefault();

        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;
        const lembrarMe = document.getElementById('remember')?.checked || false;

        if (!username || !password) {
            alert('Preencha usuário e senha.');
            return;
        }

        try {
            const response = await fetch('https://localhost:44360/api/Auth/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    username: username,
                    senha: password
                })
            });

            if (!response.ok) throw new Error('Usuário ou senha inválidos.');

            const data = await response.json();
            console.log('Login bem-sucedido:', data);

            // Armazena token
            if (lembrarMe) {
                localStorage.setItem('token', data.token);
                localStorage.setItem('expiracao', data.expiracao);
            } else {
                sessionStorage.setItem('token', data.token);
                sessionStorage.setItem('expiracao', data.expiracao);
            }

            // Redireciona para home
            window.location.href = '/Home';
            

        } catch (error) {
            console.error('Erro ao fazer login:', error);
            alert('Erro ao fazer login. Verifique suas credenciais.');

        }
    });
}

// --- Inicializar ---
document.addEventListener('DOMContentLoaded', () => {
    configurarLogin();
    carregarTickets();
});
