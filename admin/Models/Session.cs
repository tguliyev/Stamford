namespace admin.Models
{
    public static class Session
    {
        public static bool CheckSession(HttpContext httpContext)
        {
            bool isSession = true;

           if(httpContext.Session.Keys.Count() > 1){
            isSession = true;
           }
           else isSession = false;
            if(!isSession)httpContext.Session.Clear();
            return isSession;
            
        }
    }
}