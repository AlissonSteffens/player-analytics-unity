# Manual de Uso 

Esta é uma das principais ferramentas do projeto, responsável pela coleta de informações relacionadas ao jogo. Esta ferramenta serve para capturar e enviar ao sistema principal as seguintes informações relacionadas ao jogo:
* O tempo que o jogador leva para realizar cada tarefa no jogo (fase)
* A quantidade de mortes do jogador em cada fase
* A quantidade de erros cometidos pelo jogador
* As entradas providas pelo jogador (controles)
* O fluxo do jogador nas fases

Ela consiste em um prefab com 5 scripts.

##	Analytic

Este componente serve como um controlador para os outros cinco. Neles são inseridas informações como: nome do jogo, URL da API de captura de dados, chave de API e nome do jogar (este último pode ser requisitado ao jogador, ou ser alguma informação pré-armazenada. Além disso, também é possível ativar ou desativar os outros serviços por ele.

O script conta ainda com um campo que deve ser preenchido com o prefab do personagem principal. Este campo irá buscar pelo Animator do personagem para a detecção de estados (explicada na seção Estados)

## Key Logger

Este componente tem como principal função capturar todas as teclas pressionadas pelo jogador e enviá-las à API. Este processo consiste em uma rotina que é automaticamente chamada a cada iteração da Unity. Ele observa, as teclas que foram pressionadas nesta iteração, e envia um registro para a API com a estrutura:

```json
{
_id: "5e5e9d7512884300084b3b49",
user: "alisson",
game: "o-jogo",
category: "key",
action: "W",
time: "03/03/2020 18:09:57"
}
```

## Mouse Logger

Este componente tem como principal função capturar todas as ações de mouse executadas pelo jogador. Assim como o KeyLogger, este processo é realizado por meio de uma corrotina automática que analisa as iterações da Unity e envia registros para a API

```json
{
_id: "5e5e8f29e38e2100083af389",
user: "alisson",
game: "o-jogo",
category: "mouse",
action: "Mouse0",
value: "450;300",
time: "03/03/2020 17:09:57"
}
```
## Picture Taker

Este componente é responsável por realizar capturas de imagens da webcam do jogador e enviá-las para a API. As configurações possíveis são relacionadas ao tamanho da imagem (onde pode-se indicar a altura e largura desejada para o envio das imagens), e o intervalo de captura (que pode ser um valor em segundos ou sempre que houver uma mudança de estados.

```json
{
_id: " 5e5fad1b020b270008288366",
user: "alisson",
game: "o-jogo",
category: "image",
action: "stateChanged",
value: "data:image/jpeg;base64,........",
time: "03/03/2020 17:09:57"
}
```

## State Logger

Este componente é o mais complexo dentre os cinco e tem como função capturar informações relacionas ao estado do personagem e do jogo. Para isso ele conta com duas abordagens diferentes, uma voltada ao personagem e outra ao fluxo de jogo.

### Estados do Jogador

Os estados do jogador no jogo podem ser informados à ferramenta de duas maneiras diferentes, manual ou automaticamente.  A definição de estados manual consiste em o desenvolvedor chamar uma função pública do componente StateLogger chamada changeState() sempre que desejar informar o estado do jogador. Assim, quando o personagem pular o desenvolver precisa apenas enviar o estado “pulando”. 

```json
{
_id: "5e5face436b85d0007981715",
user: "alisson",
game: "o-jogo",
category: "state",
action: "Iddle",
time: "04/03/2020 13:28:06"
}
```

### Rastreando os Estados do Personagem Automaticamente

O rastreamento de estados do personagem pode ser feito de maneira automática com base em seu Animator. Para isso, o desenvolvedor precisa apenas inserir o prefab do personagem jogável no campo Personagem do componente Analytic. Este objeto é o responsável por controlar a máquina de estados de animações de personagem na Unity.

##	Flow Logger

Este componente é responsável por rastrear o comportamento do jogador no jogo. A intenção é compreender melhor o fluxo de cada jogar enquanto joga. Para isso, não foi possível desenvolver uma maneira automatizada, visto que cada jogo tem seus objetivos e pontos principais.
	
O rastreio é feito então por meio de chamadas. A fim de facilitar a utilização por parte dos desenvolvedores, estas chamadas foram projetadas de maneira a poder ser chamadas por meio do sistema de gatilhos e colisores da Unity. A Figura abaixo demonstra como funciona a definição de uma nova ação no fluxo de jogo na programação.


![]("docs/trigger.png")

Ao adicionar um gatilho para a colisão com a plataforma de acionamento, é possível passar o valor do novo estado de fluxo do jogo. A informação desta nova etapa no jogo é enviada para API por meio de uma requisição.


```json
{
_id: "5e6010d955c93c000817216f",
user: "alisson",
game: "o-jogo",
category: "OpenSmallDoor",
time: "04/03/2020 20:34:34"
}
```