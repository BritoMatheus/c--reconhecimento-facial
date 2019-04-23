# c-sharp-reconhecimento-facial
Projeto em asp.net MVC de reconhecimento facial consumindo os serviços do Azure.

Desenvolvido um protótipo de reconhecimento de emoções em asp.net MVC, linguagem c#. O protótipo é um site que consumindo os serviços da ferramenta AZURE. Ao inserir uma Imagem que contenham apenas uma face a aplicação requisitará os serviços do AZURE e apresentará as emoções da imagem enviada.

# Configurações de ambiente do AZURE
As parametrizações para consumir os serviços do AZURE foram inseridas no web.config nas configurações de *appSettings*, chaves *AZURE_subscriptionKey* e *AZURE_apiRoot*.

```
    <!--Configuração do serviço AZURE-->
    <add key="AZURE_subscriptionKey" value="####Sua KEY#####"/>
    <add key="AZURE_apiRoot" value="####URL#####"/>
    <!--Fim Configuração do serviço AZURE-->
```

Apenas trocando a chave para uma válida os serviços do AZURE poderão ser consumidos.
