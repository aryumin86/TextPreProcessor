using System;
namespace TPPLib
{
    /// <summary>
    /// Синглтон стеммера Поттера.
    /// </summary>
    public class Stemmer
    {
        private static Stemmer _instance;

        public static Stemmer GetInstance(){
            if(_instance == null){
                _instance = new Stemmer();
            }

            return _instance;
        }
    }
}
