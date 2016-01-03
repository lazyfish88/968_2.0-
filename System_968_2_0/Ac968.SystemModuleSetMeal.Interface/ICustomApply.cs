using Ac968.SystemModuleSetMeal.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Ac968.SystemModuleSetMeal.Interface
{
    [ServiceContract]
    public interface ICustomApply
    {
        [OperationContract]
        List<CustomApply> List(int pageIndex, out int record, int pageSize = 20);
        [OperationContract]
        CustomApply Edit(CustomApply model);
        [OperationContract]
        void UpdateState(long id,int state);
    }
}
