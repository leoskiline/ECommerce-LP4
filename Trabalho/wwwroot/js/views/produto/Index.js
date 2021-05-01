let indexProduto = {

    init: () => {
        //aqui vai tudo o que é necessário para a página funcionar no início.

        let selCategoria = document.getElementById("selCategoria")
        selCategoria.innerHTML = "<option>Carregando...</option>";
        indexProduto.obterCategorias();

    },

    enviar: () => {

        let dados = {
            nome: document.getElementById("txtNome").value,
            categoria: document.getElementById("selCategoria").value,
            prodId: document.getElementById("prodId").value
        }
        HTTPClient.post("/Produto/Gravar", dados)
            .then(result => {
                return result.json();
            })
            .then(dados => {
                if (dados.msg == "Falha ao Gravar Produto!") {
                    document.getElementById("gravou").innerHTML = "<div class='alert alert-danger alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><i class='fa fa-times-circle'></i> Falha ao Gravar Produto!</div>";
                }
                else {
                    document.getElementById("gravou").innerHTML = "<div class='alert alert-success alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><i class='fa fa-check-circle'></i> Produto " + dados.nome + " "+dados.msg+" com Sucesso!</div>";
                    document.getElementById("prodId").value = dados.id;
                }
            })
            .catch(() => {
                console.log("Falha ao Gravar");
            });
    },

    limpar: () => {
        document.getElementById("prodId").value = "";
        document.getElementById("txtNome").value = "";
        document.getElementById("selCategoria").value = "";
    },

    obterCategorias: () => {

        HTTPClient.get("/Produto/ObterCategorias")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                indexProduto.preencherCategorias(dados);
            })
            .catch(() => {
                alert("Não foi possível obter as categorias.");
            })

    },

    preencherCategorias: (dados) => {
        
        let selCategoria = document.getElementById("selCategoria")

        //abordagem 1
        let opts = "<option></option>";

        for (let i = 0; i < dados.length; i++) {

            opts += `<option value="${dados[i].id}">${dados[i].nome}</option>`;
        }

        selCategoria.innerHTML = opts;

        //abordagem 2
        //for (let i = 0; i < dados.length; i++) {

        //    let opt = document.createElement("option");
        //    opt.value = dados[i].id;
        //    opt.innerHTML = dados[i].nome;
        //    selCategoria.appendChild(opt);
        //}


    }
}


document.addEventListener("DOMContentLoaded", () => {

    indexProduto.init();

});

