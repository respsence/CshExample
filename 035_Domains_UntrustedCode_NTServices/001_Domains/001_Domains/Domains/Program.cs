using System;
using System.Runtime.Remoting;

// Создание доменов.

namespace Domains
{
    // MarshalByRefObject - разрешает доступ к объектам через границы доменов приложения в приложениях, поддерживающих удаленное взаимодействие.
    [Serializable]
    class UserProcessor //: MarshalByRefObject
    {
        public User ChangeUserName(User s, String newUserName)
        {
            Console.WriteLine("ChangeUserName, из домена с именем: {0}",
                AppDomain.CurrentDomain.FriendlyName);

            s.UserName = newUserName;
            return s;
        }
    }

    [Serializable]
    class User  //: MarshalByRefObject
    {
        public string UserName;
        public int Id;
        public override string ToString()
        {
            return String.Format("User ID:{0}, Name:{1}",this.Id,this.UserName);
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание второго домена приложения.
            AppDomain secondDomain = AppDomain.CreateDomain("Second Domain");
       
            // Создание объекта внутри второго домена.
            ObjectHandle userHandle = secondDomain.CreateInstance("Domains", "Domains.UserProcessor");
            
            // Создание прозрачного прокси-переходника для взаимодействия с объектом из другого домена.
            var userProxy = (UserProcessor)userHandle.Unwrap();
 
            // MyClass instance = (MyClass)secondDomain.CreateInstanceAndUnwrap("Domains", "Domains.MyClass");
            // Проверка: Действительно ли прозрачный переходник предоставлен?
            Console.WriteLine( RemotingServices.IsTransparentProxy(userProxy)
                                  ? "Развернутый объект является прокси-сервером."
                                  : "Развернутый объект не является прокси-сервером.");

            // Вывод на экран текущего домена приложения.
             Console.WriteLine("Метод Main находится в домене с именем: {0}",
                 AppDomain.CurrentDomain.FriendlyName);
            var user = new User() {Id = 1, UserName = "Admin"};

          // Вызов метода объекта, находящегося в другом домене приложения.
           var newUser =  userProxy.ChangeUserName(user, "New Admin");

            //Выводим состояние оригинального пользователя
            Console.WriteLine(user);
          
            //Выводим состояние нового пользователя
            Console.WriteLine(newUser);
          
            // Delay.
            Console.ReadKey();
        }
    }
}
