namespace HRAdministrationAPI
{
    public class FactoryPattern<K,T> where T: class, K, new()
    {
        public static K GetInstance()
        {
            K objk;  //Declares a variable objk of type K.
            objk = new T(); //Creates a new instance of type T and assigns it to objk
            return objk; //Returns the created object (objk)
        }
    }
}
