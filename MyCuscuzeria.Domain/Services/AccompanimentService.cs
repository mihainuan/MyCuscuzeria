using MyCuscuzeria.Domain.Arguments.Accompaniment;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class AccompanimentService : Notifiable, IAccompanimentService
    {
        //Service Repositories
        private readonly ICuscuzRepository _cuscuzRepository;
        private readonly IAccompanimentRepository _accompanimentRepository;

        //Constructor using IoC (Injeção de Dependências)
        public AccompanimentService(ICuscuzRepository cuscuzRepository, IAccompanimentRepository accompanimentRepository)
        {
            _cuscuzRepository = cuscuzRepository;
            _accompanimentRepository = accompanimentRepository;
        }

        //TODO: Later...
        public Accompaniment GetOneAccompaniment(int Accompanimentid)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AccompanimentResponse> GetAllAccompaniments()
        {
            IEnumerable<Accompaniment> typeCollection = _accompanimentRepository.GetAllAccompaniment();
            var response = typeCollection.ToList().Select(entity => (AccompanimentResponse)entity);
            return response;
        }

        public AccompanimentResponse AddAccompaniment(AddAccompanimentRequest request, int CuscuzId)
        {
            Cuscuz cuscuz = _cuscuzRepository.GetOneCuscuz(CuscuzId);

            Accompaniment accompaniment = new Accompaniment(request.AccompanimentName, request.Description, cuscuz);

            AddNotifications(accompaniment);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                accompaniment = _accompanimentRepository.AddAccompaniment(accompaniment);
            }

            return (AccompanimentResponse)accompaniment;
        }

        public Arguments.Base.Response RemoveAccompaniment(int AccompanimentId)
        {
            //Verifica se existe um Cuscuz vinculada antes de excluir o Type
            bool existCuscuz = _cuscuzRepository.ExistOrder(AccompanimentId);

            if (existCuscuz)
            {
                AddNotification("Type", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Tipo", "Cuscuz"));
                return null;
            }

            Accompaniment accompaniment = _accompanimentRepository.GetOneAccompaniment(AccompanimentId);

            if (accompaniment == null)
            {
                AddNotification("Type", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _accompanimentRepository.DeleteAccompaniment(accompaniment);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public bool ExistCuscuz(int typeId)
        {
            return _accompanimentRepository.ExistCuscuz(typeId);
        }
    }
}