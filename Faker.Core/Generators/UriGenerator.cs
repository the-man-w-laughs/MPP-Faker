using System.Text;

public class UriGenerator : IValueGenerator
{
    public bool CanGenerate(Type t)
    {
        return t == typeof(Uri);
    }

    private string getLetterString(IGeneratorContext context,int minLen, int MaxLen){
        var result = new StringBuilder();

        var len = context.Random.Next(minLen,MaxLen);
        for (int i = 0; i < len; i++){
            var index = context.Random.Next(context.Alphabet.Length);            
            result = result.Append(context.Alphabet[index]);
        }
        return result.ToString();
    }

    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        // init Fragment
        var uriBuilder = new UriBuilder();
        uriBuilder.Fragment = '#' + getLetterString(context,0,10);

        // init host
        var host = new StringBuilder();
        var subdomainCount = context.Random.NextInt64(1,10);
        for (int i = 0; i < subdomainCount; i++){
            host.Append(getLetterString(context,1,10));
            host.Append('.');
        }
        switch (context.Random.NextInt64(0,5)){
            case 0:
                host.Append("by");                
                break;
            case 1:
                host.Append("ru");
                break;
            case 2:
                host.Append("com");
                break;
            case 3:
                host.Append("org");
                break;
            case 4:            
                host.Append("org");
                break;
        }
        uriBuilder.Host = host.ToString();

        // init UserInfo
        if (context.Random.NextDouble() <= 0.3){
            uriBuilder.Password = getLetterString(context,8,16);
            uriBuilder.UserName = getLetterString(context,8,16);
        }    

        // init Scheme
        uriBuilder.Scheme = context.Random.NextDouble() >= 0.5 ? "https:" : "http:";

        //  init Path
        var path = new StringBuilder();
        var subdirCount = context.Random.Next(0,5);
        for (int i = 0; i < subdirCount; i++)
        {                      
            path.Append('/');
            path.Append(getLetterString(context,0,10));
        }
        uriBuilder.Path = path.ToString();

        // init port    
        if (context.Random.NextDouble() <= 0.3){
            uriBuilder.Port = context.Random.Next(65536);
        }    

        // init query
        var queryNum = context.Random.NextInt64(0,5);
        var query = new StringBuilder();
        for (int i = 0; i < queryNum; i++){        
            if (i > 0){
                query.Append('&');
            }
            else{
                query.Append('?');
            }
            query.Append(getLetterString(context,0,10));
            query.Append('=');
            query.Append(getLetterString(context,0,10));
        } 
        uriBuilder.Query = query.ToString();
        return uriBuilder.Uri;
    }
}