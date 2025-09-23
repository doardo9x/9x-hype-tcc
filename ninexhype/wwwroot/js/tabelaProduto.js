document.addEventListener('DOMContentLoaded', function () {
    let selectedRowId = null;

    // Adiciona evento de clique às linhas da tabela
    document.querySelectorAll('#tabelaProdutos tbody tr').forEach(row => {
        row.addEventListener('click', function () {
            // Remove a seleção de outras linhas
            document.querySelectorAll('#tabelaProdutos tbody tr').forEach(r => r.classList.remove('selected'));
            
            // Marca a linha atual como selecionada
            this.classList.add('selected');
            selectedRowId = this.getAttribute('data-id'); // Armazena o ID do produto selecionado
        });
    });

    // Adiciona evento de clique aos botões
    document.querySelectorAll('.botoes .botao a').forEach(button => {
        button.addEventListener('click', function (e) {
            e.preventDefault(); // Evita o comportamento padrão do link

            if (!selectedRowId) {
                alert('Por favor, selecione um produto antes de realizar uma ação.');
                return;
            }

            const action = this.id; // Obtém o ID do botão clicado

            if (action === 'btnEditar') {
                window.location.href = `/Produtos/Edit/${selectedRowId}`;
            } else if (action === 'btnDetalhes') {
                window.location.href = `/Produtos/Details/${selectedRowId}`;
            } else if (action === 'btnDeletar') {
                if (confirm('Tem certeza que deseja deletar este produto?')) {
                    window.location.href = `/Produtos/Delete/${selectedRowId}`;
                }
            }
        });
    });
});