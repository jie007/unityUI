
public class Singleton<T> where T : new()
{
    private static T _instance = default(T);
    private static readonly System.Object _lock = new System.Object();

    protected Singleton() {}

	public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                    return _instance;
                }
            }
            return _instance;
        }
    }
}
