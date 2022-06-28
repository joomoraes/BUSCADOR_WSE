

$(document).ready(function () {
    var meses = [
        "Janeiro",
        "Fevereiro",
        "Março",
        "Abril",
        "Maio",
        "Junho",
        "Julho",
        "Agosto",
        "Setembro",
        "Outubro",
        "Novembro",
        "Dezembro"
    ];
    var days = ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'];
    var data = '18/05/17';
    var formatData = data.replace(/(\d{2})(\/)(\d{2})/, "$3$2$1");
    var newData = new Date(formatData);

    console.log(newData.getDate() + ' ' + meses[newData.getMonth()] + ' (' + days[newData.getDay()] + ')')

    var tiempo = {};
    var clock = new Date("2016-06-01 5:00:00 PM"); // Obtener la fecha y almacenar en clock
    var intervalo = window.setInterval(mostrar_hora, 1); // Frecuencia de actualización
    var i = 0; // Esta variable me ayudará a definir los estados de intervalo

    function mostrar_hora() {
        var now = new Date();
        // Inserta la hora almacenada en clock en el span con id hora
        tiempo.horas = document.getElementById('horas');
        tiempo.horas.innerHTML = clock.getHours() - now.getHours();
        tiempo.horas = document.getElementById('horaLogin');
        tiempo.horas.innerHTML = clock.getHours() - now.getHours();

        // Inserta los minutos almacenados en clock en el span con id minuto
        tiempo.minuto = document.getElementById('minutos');
        tiempo.minuto.innerHTML = clock.getMinutes() + 60 - now.getMinutes();

        tiempo.minuto = document.getElementById('minutosLogin');
        tiempo.minuto.innerHTML = clock.getMinutes() + 60 - now.getMinutes();

        // Inserta los segundos almacenados en clock en el span con id segundo
        tiempo.segundos = document.getElementById('segundos')
        tiempo.segundos.innerHTML = "0" + clock.getSeconds() + 60 - now.getSeconds();
    }

  

    var spec = {
        "openapi": "3.0.1",
        "info": {
            "version": "1.0.0",
            "title": "API Specification Example"
        },
        "paths": {
            "/articles": {
                "post": {
                    "summary": "Create an article.",
                    "operationId": "createArticle",
                    "tags": [
                        "Article API"
                    ],
                    "requestBody": {
                        "content": {
                            "application/json": {
                                "schema": {
                                    "$ref": "#/components/schemas/Article"
                                }
                            }
                        }
                    },
                    "responses": {
                        "201": {
                            "description": "Success",
                            "content": {
                                "application/json": {
                                    "schema": {
                                        "$ref": "#/components/schemas/Article"
                                    }
                                }
                            }
                        },
                        "400": {
                            "$ref": "#/components/responses/IllegalInput"
                        }
                    }
                },
                "get": {
                    "summary": "Get a list of articles",
                    "operationId": "listArticles",
                    "tags": [
                        "Article API"
                    ],
                    "parameters": [
                        {
                            "$ref": "#/components/parameters/Limit"
                        },
                        {
                            "$ref": "#/components/parameters/Offset"
                        }
                    ],
                    "responses": {
                        "200": {
                            "description": "Success",
                            "content": {
                                "application/json": {
                                    "schema": {
                                        "$ref": "#/components/schemas/ArticleList"
                                    }
                                }
                            }
                        }
                    }
                }
            },
            "/articles/{id}": {
                "get": {
                    "summary": "Get an article.",
                    "operationId": "getArticle",
                    "tags": [
                        "Article API"
                    ],
                    "parameters": [
                        {
                            "$ref": "#/components/parameters/Id"
                        }
                    ],
                    "responses": {
                        "200": {
                            "description": "Success",
                            "content": {
                                "application/json": {
                                    "schema": {
                                        "$ref": "#/components/schemas/Article"
                                    }
                                }
                            }
                        },
                        "404": {
                            "$ref": "#/components/responses/NotFound"
                        }
                    }
                },
                "put": {
                    "summary": "Update",
                    "operationId": "updateArticle",
                    "tags": [
                        "Article API"
                    ],
                    "parameters": [
                        {
                            "$ref": "#/components/parameters/Id"
                        }
                    ],
                    "requestBody": {
                        "content": {
                            "application/json": {
                                "schema": {
                                    "$ref": "#/components/schemas/Article"
                                }
                            }
                        }
                    },
                    "responses": {
                        "200": {
                            "description": "Success",
                            "content": {
                                "application/json": {
                                    "schema": {
                                        "$ref": "#/components/schemas/Article"
                                    }
                                }
                            }
                        },
                        "404": {
                            "$ref": "#/components/responses/NotFound"
                        }
                    }
                },
                "delete": {
                    "summary": "Delete an article.",
                    "operationId": "deleteArticle",
                    "tags": [
                        "Article API"
                    ],
                    "parameters": [
                        {
                            "$ref": "#/components/parameters/Id"
                        }
                    ],
                    "responses": {
                        "204": {
                            "description": "Success"
                        },
                        "404": {
                            "$ref": "#/components/responses/NotFound"
                        }
                    }
                }
            }
        },
        "components": {
            "schemas": {
                "Id": {
                    "description": "Resource ID",
                    "type": "integer",
                    "format": "int64",
                    "readOnly": true,
                    "example": 1
                },
                "ArticleForList": {
                    "properties": {
                        "id": {
                            "$ref": "#/components/schemas/Id"
                        },
                        "category": {
                            "description": "Category of an article",
                            "type": "string",
                            "example": "sports"
                        }
                    }
                },
                "Article": {
                    "allOf": [
                        {
                            "$ref": "#/components/schemas/ArticleForList"
                        }
                    ],
                    "required": [
                        "text"
                    ],
                    "properties": {
                        "text": {
                            "description": "Content of an article",
                            "type": "string",
                            "maxLength": 1024,
                            "example": "# Title\n\n## Head Line\n\nBody"
                        }
                    }
                },
                "ArticleList": {
                    "type": "array",
                    "items": {
                        "$ref": "#/components/schemas/ArticleForList"
                    }
                },
                "Error": {
                    "description": "<table>\n  <tr>\n    <th>Code</th>\n    <th>Description</th>\n  </tr>\n  <tr>\n    <td>illegal_input</td>\n    <td>The input is invalid.</td>\n  </tr>\n  <tr>\n    <td>not_found</td>\n    <td>The resource is not found.</td>\n  </tr>\n</table>\n",
                    "required": [
                        "code",
                        "message"
                    ],
                    "properties": {
                        "code": {
                            "type": "string",
                            "example": "illegal_input"
                        }
                    }
                }
            },
            "parameters": {
                "Id": {
                    "name": "id",
                    "in": "path",
                    "description": "Resource ID",
                    "required": true,
                    "schema": {
                        "$ref": "#/components/schemas/Id"
                    }
                },
                "Limit": {
                    "name": "limit",
                    "in": "query",
                    "description": "limit",
                    "required": false,
                    "schema": {
                        "type": "integer",
                        "minimum": 1,
                        "maximum": 100,
                        "default": 10,
                        "example": 10
                    }
                },
                "Offset": {
                    "name": "offset",
                    "in": "query",
                    "description": "offset",
                    "required": false,
                    "schema": {
                        "type": "integer",
                        "minimum": 0,
                        "default": 0,
                        "example": 10
                    }
                }
            },
            "responses": {
                "NotFound": {
                    "description": "The resource is not found.",
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/Error"
                            }
                        }
                    }
                },
                "IllegalInput": {
                    "description": "The input is invalid.",
                    "content": {
                        "application/json": {
                            "schema": {
                                "$ref": "#/components/schemas/Error"
                            }
                        }
                    }
                }
            }
        }
    }

    const ui = SwaggerUIBundle({
        spec: spec,
        dom_id: '#swagger-ui',
        deepLinking: true,
        presets: [
            SwaggerUIBundle.presets.apis,
            SwaggerUIStandalonePreset
        ],
        plugins: [
            SwaggerUIBundle.plugins.DownloadUrl
        ],
        layout: "StandaloneLayout"
    })

    window.ui = ui

    $('#monthname').html(meses[newData.getMonth()]);
});

$(function () {
    $('#apis').click(function () {
        $.ajax({
            url: 'Apis',
            cache: false,
            method: 'Post',
            success: function (result) {
                $('#PortfolioTop').css('display', 'none', '!important');
                $('#PortfolioFot').css('display', 'none', '!important');
                $('#apisDIV').html(result);

            }
        });
    });
});

function enviarEmail() {
    swal("Email:", {
        icon: "warning",
        content: "input",
        buttons: true,
        dangerMode: true,
    })
        .then((value) => {
            let valor = value;
            swal("Descrição:", {
                content: "input",
            })
                .then((value) => {
                    swal("Email Enviado Para", "joaopedro@azure.wsematogrosso.com", "success");

                });
        });
        
}

function Index() {
    $.ajax({
        url: 'Index',
        cache: false,
        method: 'Post',
        success: function (result) {
            $('#PortfolioTop').css('display', 'flex', '!important');
            $('#PortfolioFot').css('display', 'flex', '!important');
            $('#trabalhos').css('display', 'none');
        }
    });
}

function Trabalhos()
{

    $.ajax({
        url: 'Trabalhos',
        cache: false,
        method: 'Post',
        success: function (result) {
            $('#PortfolioFot').css('display', 'none', '!important');
            $('#PortfolioTop').css('display', 'none', '!important');
            $('#trabalhos').html(result);
        }
    });
}

function Projetos() {
    $.ajax({
        url: 'Projetos',
        cache: false,
        method: 'Post',
        success: function (result) {
            $('#PortfolioTop').css('display', 'none', '!important');
            $('#PortfolioFot').css('display', 'none', '!important');
            $('#projetos').html(result);
        }
    });
}

function Curriculo() {
    $.ajax({
        url: 'Curriculo',
        cache: false,
        method: 'Post',
        success: function (result) {
            $('#curriculo').html(result);
            $('.wrapper').css('display', 'none');
        }
    })
}
