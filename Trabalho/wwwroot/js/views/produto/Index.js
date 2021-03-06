
let indexProduto = {

    init: () => {
        //aqui vai tudo o que é necessário para a página funcionar no início.

        let selCategoria = document.getElementById("selCategoria")
        selCategoria.innerHTML = "<option>Carregando...</option>";
        indexProduto.obterCategorias();

    },

    enviar: () => {
        let nome = document.getElementById("txtNome").value;
        let categoria = document.getElementById("selCategoria").value;
        let prodId = document.getElementById("prodId").value;
        let file = document.getElementById("fImagem").files[0];
        let formData = new FormData();
        formData.append("nome", nome);
        formData.append("categoria", categoria);
        formData.append("prodId", prodId);
        formData.append("file", file);
        HTTPClient.postFormData("/Produto/Gravar", formData)
            .then(result => {
                return result.json();
            })
            .then(dados => {
                if (dados.msg == "Falha ao Gravar Produto!") {
                    document.getElementById("gravou").innerHTML = "<div class='alert alert-danger alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><i class='fa fa-times-circle'></i> Falha ao Gravar Produto!</div>";
                }
                else {
                    document.getElementById("gravou").innerHTML = "<div class='alert alert-success alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><i class='fa fa-check-circle'></i> Produto " + dados.nome + " " + dados.msg + "</div>";
                    document.getElementById("prodId").value = dados.id;
                }
            });
        /*
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
                    indexProduto.enviarImagem(dados.id);
                    document.getElementById("gravou").innerHTML = "<div class='alert alert-success alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>×</span></button><i class='fa fa-check-circle'></i> Produto " + dados.nome + " " + dados.msg + " com Sucesso!</div>";
                    document.getElementById("prodId").value = dados.id;
                }
                
            })
            .catch(() => {
                console.log("Falha ao Gravar");
            });*/
    },

    enviarImagem: (id) => {
        let fImagem = document.getElementById("fImagem");
        let file = fImagem.files[0];
        let formData = new FormData();
        formData.append("imagem", file);
        formData.append("id", id);
        HTTPClient.postFormData("/Produto/GravarImagem", formData);

        /*let fImagem = document.getElementById("fImagem");
        if (fImagem.files.length == 0) {
            alert("Selecione uma imagem.");
        }
        else {
            let file = fImagem.files[0];
            if (file.size > 153600) // 150KB
            {
                alert("Imagem Muito Grande");
            }
            else {
                if (file.type == "image/jpeg" || ile.type == "image/jpg" || file.type == "image/png") {
                    let formData = new FormData();
                    formData.append("imagem", file);
                    formData.append("id", id);
                    HTTPClient.postFormData("/Produto/GravarImagem", formData);
                }
                else {
                    alert("Formato de arquivo nao suportado.");
                }
            }
        }*/
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

