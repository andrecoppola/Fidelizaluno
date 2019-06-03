import { request } from '../../assets/functions/func';
import $ from 'jquery';
const config = require('../../../config')

export default class ServiceCadastro {

    createCadastro(Nome, Email, Cpf, TelefoneCelular,
        TelefoneResidencial, Genero, Cep,
        Logradouro, Bairro, Numero, Municipio, Uf, Complemento, CodigoMunicipio, IdTipoPessoa) {
        return request("POST", `${config.react.api.baseUrl}/pessoa`, {
            "Nome": Nome,
            "Email": Email,
            "Cpf": Cpf,
            "TelefoneCelular": TelefoneCelular,
            "TelefoneResidencial": TelefoneResidencial,
            "Genero": Genero,
            "Endereco": {
                "Cep": Cep,
                "Logradouro": Logradouro,
                "Bairro": Bairro,
                "Numero": Numero,
                "Municipio": Municipio,
                "Uf": Uf,
                "Complemento": Complemento,
                "CodigoMunicipio": CodigoMunicipio
            },
            "IdTipoPessoa": IdTipoPessoa
        }, {
                'Content-Type': 'application/json',
            }
        );
    }

    pesquisaCEP(){
        $(document).ready(function () {

            function limpa_formulário_cep() {
                // Limpa valores do formulário de cep.
                $("#rua").val("");
                $("#bairro").val("");
                $("#cidade").val("");
                $("#uf").val("");
            }

            //Quando o campo cep perde o foco.
            $("#cep").blur(function () {

                //Nova variável "cep" somente com dígitos.
                var cep = $(this).val().replace(/\D/g, '');

                //Verifica se campo cep possui valor informado.
                if (cep !== "") {

                    //Expressão regular para validar o CEP.
                    var validacep = /^[0-9]{8}$/;

                    //Valida o formato do CEP.
                    if (validacep.test(cep)) {

                        //Preenche os campos com "..." enquanto consulta webservice.
                        $("#rua").val("...");
                        $("#bairro").val("...");
                        $("#cidade").val("...");
                        $("#uf").val("...");

                        //Consulta o webservice viacep.com.br/
                        $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#rua").val(dados.logradouro);
                                $("#bairro").val(dados.bairro);
                                $("#cidade").val(dados.localidade);
                                $("#uf").val(dados.uf);
                            } else {
                                //CEP pesquisado não foi encontrado.
                                limpa_formulário_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                    } else {
                        //cep é inválido.
                        limpa_formulário_cep();
                        alert("Formato de CEP inválido.");
                    }
                } else {
                    //cep sem valor, limpa formulário.
                    limpa_formulário_cep();
                }
            });
        });
    }

}