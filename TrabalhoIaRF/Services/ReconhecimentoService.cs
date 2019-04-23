using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using TrabalhoIaRF.Models;

namespace TrabalhoIaRF.Services
{
    public class ReconhecimentoService
    {
        private readonly IFaceServiceClient _faceServiceCliente;

        public ReconhecimentoService()
        {
            string key = WebConfigurationManager.AppSettings["AZURE_subscriptionKey"];
            string url = WebConfigurationManager.AppSettings["AZURE_apiRoot"];
            _faceServiceCliente = new FaceServiceClient(key, url);
        }


        public async Task<Retorno> BuscarEmocao(Stream fileStream)
        {
            Face[] lstFaces = await Buscar(fileStream);

            if (lstFaces.Length == 0)
                return new Retorno()
                {
                    Mensagem = "Não identificamos nenhum rosto na imagem enviada.",
                    Sucesso = false
                };

            if (lstFaces.Length > 1)
                return new Retorno()
                {
                    Mensagem = "Identificamos mais de uma face. Selecione uma imagem que contenha apenas uma pessoa.",
                    Sucesso = false
                };

            Face face = lstFaces.FirstOrDefault();

            //Validações com o retorno
            if (face.FaceId == null)
                return new Retorno()
                {
                    Mensagem = "Não identificamos nenhum rosto na imagem enviada.",
                    Sucesso = false
                };

            var lstEmocoes = new List<Emocao>();

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Raiva",
                    Valor = face.FaceAttributes.Emotion.Anger
                });

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Desprezo",
                    Valor = face.FaceAttributes.Emotion.Contempt
                });

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Desgosto",
                    Valor = face.FaceAttributes.Emotion.Disgust
                });

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Medo",
                    Valor = face.FaceAttributes.Emotion.Fear
                });

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Felicidade",
                    Valor = face.FaceAttributes.Emotion.Happiness
                });

            lstEmocoes.Add(
                new Emocao()
                {
                    Cor = "",
                    Nome = "Imparcial",
                    Valor = face.FaceAttributes.Emotion.Neutral
                });

            lstEmocoes.Add(
               new Emocao()
               {
                   Cor = "",
                   Nome = "Triste",
                   Valor = face.FaceAttributes.Emotion.Sadness
               });

            lstEmocoes.Add(
             new Emocao()
             {
                 Cor = "",
                 Nome = "Surpreso",
                 Valor = face.FaceAttributes.Emotion.Surprise
             });


            return new Retorno(lstEmocoes.OrderByDescending(x => x.Valor).Where(x => x.Valor > 0).ToList());
        }

        private async Task<Face[]> Buscar(Stream fileStream) => await _faceServiceCliente.DetectAsync(fileStream, returnFaceAttributes: MontarAtributos());

        private List<FaceAttributeType> MontarAtributos()
        {
            var lst = new List<FaceAttributeType>();
            lst.Add(FaceAttributeType.Emotion);
            lst.Add(FaceAttributeType.Gender);
            return lst;
        }
    }
}