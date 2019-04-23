using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using Type = MyCuscuzeria.Domain.Entities.Type;

namespace MyCuscuzeria.Domain.Services
{
    public class TypeService : Notifiable, ITypeService
    {
        //Repositories
        private readonly ICuscuzRepository _cuscuzRepository;
        private readonly ITypeRepository _typeRepository;

        //Constructor using IoC (Injeção de Dependências)
        public TypeService(ICuscuzRepository cuscuzRepository, ITypeRepository typeRepository)
        {
            _cuscuzRepository = cuscuzRepository;
            _typeRepository = typeRepository;
        }

        //TODO: Later...
        public Type GetOneType(int typeid)
        {
            throw new System.NotImplementedException();
        }

        //Section 2, Class 20 (22:08)
        public IEnumerable<TypeResponse> GetAllTypes()
        {
            IEnumerable<Type> typeCollection = _typeRepository.GetAllTypes();
            var response = typeCollection.ToList().Select(entity => (TypeResponse)entity);
            return response;
        }

        public TypeResponse AddType(AddTypeRequest request, int cuscuzId)
        {
            Cuscuz cuscuz = _cuscuzRepository.GetOneCuscuz(cuscuzId);

            Type type = new Type(request.TypeName, request.Description, cuscuz);

            AddNotifications(cuscuz);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                type = _typeRepository.AddType(type);
            }

            return (TypeResponse)type;
        }

        public Arguments.Base.Response RemoveType(int typeId)
        {
            //Verifica se existe um Cuscuz vinculada antes de excluir o Type
            bool existCuscuz = _typeRepository.ExistCuscuz(typeId);

            if (existCuscuz)
            {
                AddNotification("Type", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Tipo", "Cuscuz"));
                return null;
            }

            Type type = _typeRepository.GetOneType(typeId);

            if (type == null)
            {
                AddNotification("Type", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _typeRepository.DeleteType(type);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        //Checks if Type exists in ANY Cuscuz
        public bool ExistCuscuz(int typeId)
        {
            return _typeRepository.ExistCuscuz(typeId);
        }
    }
}