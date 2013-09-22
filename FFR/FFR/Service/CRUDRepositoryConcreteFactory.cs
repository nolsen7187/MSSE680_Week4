using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFR;
using System.Reflection;

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

    public abstract class CRUDRepositoryConcreteFactory
    {
    public static Boolean globalActionType = false, 
                          globalRepostioryType = false;

    public static Type type;// = Type.GetType(_repositoryType);
    public static Object classObjectLocallyDeclared;// = Activator.CreateInstance(type);
    public static Class dynamicClass;

   

        public static IDataRepository CRUD(Int16 _actionType, String _repositoryType)
        {
            IDataRepository modifiedRepository;
            //Validate Parameters being passed into Factory
            ValidateParameters validParameters = new ValidateParameters();

            //Validating action type is set to a legit value.(CRUD)
            validParameters.ValidateParameter(_actionType);

            //Validating repository is set to a legit value.
            validParameters.ValidateParameter(_repositoryType);

            //If both parameters are true the application can process the request accordingly.
            if (globalActionType && globalRepostioryType)
            {
               //dynamicClass =Activator.CreateInstance(
                classObjectLocallyDeclared 
                //modifiedRepository = (T)Activator.CreateInstance(Type.GetType(_repositoryType));
                //type = Type.GetType(_repositoryType);
                classObjectLocallyDeclared = Activator.CreateInstance(type);
                switch (_actionType)
                {
                    case 1://Create
                        modifiedRepository = new DataRepository<>();
                        break;
                    /*case 2://Read
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                    case 3://Update
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                    case 4://Delete
                        modifiedRepository = new DataRepository<Customer>();
                        break;*/
                    default:
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                }
                return modifiedRepository;
            }
            else
            {
            throw new System.ArgumentException("Invalid Parameters passed to CRUDRepositoryConcreteFactory/ValidateParameters class." );
            }
        }
    }
    //Valid parameters passed to this factory
    class ValidateParameters : CRUDRepositoryConcreteFactory
    {
        public Boolean ValidateParameter(int _actionType)
        {
            if ((_actionType > 0) && (_actionType < 5))
            {
                globalActionType = true;             
            }
            else
            {
                globalActionType = false;
                throw new System.ArgumentException("Invalid Action type of {0} passed to CRUDRepositoryConcreteFactory/ValidateParameters class, ValidateActionType Method" + _actionType);
            }
            return globalActionType;
        }
        public Boolean ValidateParameter(string _repositoryType)
        {
            switch (_repositoryType)
            {
                case "Customer":
                    globalRepostioryType = true;
                    break;
                case "Item":
                    globalRepostioryType = true;
                    break;
                case "Employee":
                    globalRepostioryType = true;
                    break;
                case "SalesHeader":
                    globalRepostioryType = true;
                    break;
                case "SalesItem":
                    globalRepostioryType = true;
                    break;
                default:
                    globalRepostioryType = false;
                    throw new System.ArgumentException("Invalid Repository type of {0} passed to CRUDRepositoryConcreteFactory/ValidateParameters class, ValidateActionType Method" + _repositoryType);
            }
            return globalRepostioryType;
        }
    }

}
