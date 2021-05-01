
listarCategoria = {

    init: () => {
        listarCategoria.obterCategorias();
    },

    obterCategorias: () => {

        HTTPClient.get("/Categoria/ObterTodos")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                listarCategoria.preencherCategorias(dados);
            })
            .catch(() => {
                alert("Não foi possível obter as categorias.");
            })

    },

    preencherCategorias: (dados) => {

        document.getElementById("divResultado").classList.remove("d-none");

        let bodyResultado = document.getElementById("bodyResultado");

        let linhas = "";

        dados.forEach(item => {

            linhas += `<tr data-categoria-id=${item.id}>
                            <td>${item.nome}</td>
                            <td>
                                <button 
                                    onclick="listarCategoria.excluir(${item.id},'${item.nome}')"
                                    type="button" 
                                    class="btn">
                                        <i class="fa fa-trash"></i>
                                </button></td>
                       </tr>`
        });

        bodyResultado.innerHTML = linhas;

    },

    excluir: (id, nome) => {
        
        if (!confirm(`Deseja excluir "${nome}" ?`))
            return;

        //ajax -> id
        HTTPClient.delete("/Categoria/Excluir?id=" + id)
            .then(r => {
                return r.json();
            })
            .then(dados => {

                if (dados.sucesso) {
                    listarCategoria.removerLinha(id);
                    alert("Removido com Sucesso!!!");
                }
                else
                    alert("Falha ao Remover Categoria pois esta em uso.");
            })
            .catch(() => {

                alert("Deu erro");
            });
    
    },

    removerLinha: (id) => {

        let tr = document.querySelector(`tr[data-categoria-id='${id}']`);
        document.getElementById("bodyResultado").removeChild(tr);
    }
     
}

document.addEventListener("DOMContentLoaded", () => {

    listarCategoria.init();

});