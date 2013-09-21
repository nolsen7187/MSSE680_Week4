using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFR;

namespace FFR.Service
{
    //_actionType value 1 = Create
    //_actionType value 2 = Read
    //_actionType value 3 = Update
    //_actionType value 4 = Delete

    //_repositoryType value 1 = Customer
    //_repositoryType value 2 = Item
    //_repositoryType value 3 = Employee
    //_repositoryType value 4 = SalesHeader
    //_repositoryType value 5 = Customer

    class CRUDRepositoryConcreteFactory
    {
    public static Boolean validActionType = false, 
                          repostioryType = false;

        public static IDataRepository CRUD(int _actionType, string _repositoryType)
        {
            IDataRepository modifiedRepository;

            modifiedRepository = new DataRepository<Customer>();

            return modifiedRepository;
        }
    }
    class ValidateParameters : CRUDRepositoryConcreteFactory
    {
        public Boolean ValidateActionType(int _actionType)
        {
            if ((_actionType > 0) && (_actionType < 5))
            {
                validActionType = true;             
            }
            else
            {              
                validActionType = false;
            }
            return validActionType;
        }
        public Boolean ValidateActionType(string _repositoryType)
        {
            switch (_repositoryType)
            {
                case "Customer":
                    repostioryType = true;
                    break;
                case "Item":
                    repostioryType = true;
                    break;
                case "Employee":
                    repostioryType = true;
                    break;
                case "SalesHeader":
                    repostioryType = true;
                    break;
                case "SalesItem":
                    repostioryType = true;
                    break;
                default:
                    repostioryType = false;
                    throw new System.ArgumentException("Invalid Repository type of {0} passed to CRUDRepositoryConcreteFactory/ValidateParameters class, ValidateActionType Method" + _repositoryType);
            }
            return repostioryType;
        }
    }
}
