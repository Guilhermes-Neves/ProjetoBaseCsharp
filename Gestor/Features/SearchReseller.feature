#language: pt

Funcionalidade: Buscar revendedora

Cenário: Buscar revendedoras
    Dado que estou na página de revendedoras
    Quando busco uma revendedora pelo "<valor>" no campo "<campo>"
    Então visualizo apenas a revendedora correspondente pelo "<valor>" no campo "<campo>"

    Exemplos: 
        | valor                | campo      |
        | MARCIO MARCOS GOMILA | nome       |
        | 000.741.577-01       | cpf        |
        | 810437               | codStyllus |

Cenário: Buscar revendedora não cadastrada
    Dado que estou na página de revendedoras
    Quando busco uma revendedora pelo "78432947329" no campo "codStyllus"
    Então não visualizo nenhuma revendedora com o codigo "78432947329"