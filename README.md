# Study_EventManager

    void Register(int key, EventMgr eventMgr);//注册事件

    void UnRegister(int key);//解绑事件

    void ClearAll();//解绑所有事件

    bool IsRegisterName(int key);//key值是否被注册

    bool IsRegisterFunc(EventMgr eventMgr);//eventMgr是否被注册

    void Invoke(int key, params object[] param);//调用
