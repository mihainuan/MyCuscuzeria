﻿using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using Response = MyCuscuzeria.Domain.Arguments.Base.Response;
using Type = MyCuscuzeria.Domain.Entities.Type;

namespace MyCuscuzeria.Domain.Services
{
    public class TypeService : Notifiable, ITypeService
    {
        private readonly ICuscuzRepository _cuscuzRepository;
        private readonly ITypeRepository _typeRepository;

        public TypeService(ICuscuzRepository cuscuzRepository, ITypeRepository typeRepository)
        {
            _cuscuzRepository = cuscuzRepository;
            _typeRepository = typeRepository;
        }

        public TypeResponse AddType(AddTypeRequest request, int CuscuzId)
        {
            Cuscuz cuscuz = _cuscuzRepository.GetCuscuz(CuscuzId);

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

        public Response RemoveType(int TypeId)
        {
            throw new System.NotImplementedException();
        }

        public Type GetOneType(int typeid)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TypeResponse> GetAllTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}