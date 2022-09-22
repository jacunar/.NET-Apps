using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServices {
    [ServiceContract]
    public interface ICalculadoraService {
        [OperationContract]
        double Sumar(double a, double b);

        [OperationContract]
        double Restar(double a, double b);

        [OperationContract]
        double Multiplicar(double a, double b);

        [OperationContract]
        double Dividir(double a, double b);
    }
}
