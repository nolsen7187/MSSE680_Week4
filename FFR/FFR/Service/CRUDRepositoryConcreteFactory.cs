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
        //public static Boolean _globalActionType = false,
        //                      _globalRepostioryType = false;

        //public static Type _type;// = Type.GetType(_repositoryType);
        //public static Object _classObjectLocallyDeclared;// = Activator.CreateInstance(type);
        //public static Class dynamicClass;



        //public static IDataRepository CRUD<T>() where T: class
        public static DataRepository<T> CRUD<T>() where T : class
        {
            DataRepository<T> modifiedRepository = Activator.CreateInstance<DataRepository<T>>();
            return modifiedRepository;
        }

    }
}
            //modifiedRepository = Activator.CreateInstance<DataRepository<T>>();
            //Validate Parameters being passed into Factory
            //ValidateParameters validParameters = new ValidateParameters();

            //Validating action type is set to a legit value.(CRUD)
          //  validParameters.ValidateParameter(_actionType);

            //Validating repository is set to a legit value.
           // validParameters.ValidateParameter(_repositoryType);

            //If both parameters are true the application can process the request accordingly.
           //if (_globalActionType )//&& _globalRepostioryType)
            //{

 //               modifiedRepository = Activator.CreateInstance<DataRepository<T>>();
//                if(modifiedRepository.)
//                {
//                return modifiedRepository;
//                }
//                else
 //               {
   //             throw new System.ArgumentException("No repository found based on the caller passed to the CRUDRepositoryConcreteFactory/CRUD method.");
     //           }
                //Type type = cust.GetType();

               // modifiedRepository = new DataRepository<T>(); 



                /*classObjectLocallyDeclared 
                modifiedRepository = (T)Activator.CreateInstance(Type.GetType(_repositoryType));
                type = Type.GetType(_repositoryType);
                classObjectLocallyDeclared = Activator.CreateInstance(type);*/

               /* switch (_actionType)
                {
                    case 1://Create
                        modifiedRepository.Create(Customer);// = new DataRepository<Customer>();
                        break;
                    case 2://Read
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                    case 3://Update
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                    case 4://Delete
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                    default:
                        modifiedRepository = new DataRepository<Customer>();
                        break;
                }*/



   /* //Valid parameters passed to this factory
    class ValidateParameters : CRUDRepositoryConcreteFactory
    {
        public Boolean ValidateParameter(Int16 _actionType)
        {
            if ((_actionType > 0) && (_actionType < 5))
            {
                _globalActionType = true;
            }
            else
            {
                _globalActionType = false;
                throw new System.ArgumentException("Invalid Action type of {0} passed to CRUDRepositoryConcreteFactory/ValidateParameters class, ValidateActionType Method" + _actionType);
            }
            return _globalActionType;
        }
        public void ValidateParameter<T>(T _repositoryType) where T: class
        {

            if (_repositoryType.GetType() == typeof(Customer))
                _globalRepostioryType = true;
            else
                throw new ArgumentException("Invalid Repository type of {0} passed to CRUDRepositoryConcreteFactory/ValidateParameters class, ValidateActionType Method" + _repositoryType);

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
        }
    }
}
*/