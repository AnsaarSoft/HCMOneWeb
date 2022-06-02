namespace HCM.API.General
{
    public class DBValidation
    {
        public static object ValidateType(object var, Type type)
        {
            try
            {
                if (type == typeof(int))
                {
                    if (Convert.IsDBNull(var))
                    {
                        var = 0;
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = 0;
                    }
                }
                else if (type == typeof(string))
                {
                    if (var == null)
                    {
                        var = "";
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = "";
                    }
                }
                else if (type == typeof(object))
                {
                    if (var == null)
                    {
                        var = "";
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = "0";
                    }
                }
                else if (type == typeof(DateTime))
                {

                    if (Convert.IsDBNull(var))
                    {
                        var = "";
                    }
                    else
                    {
                        var = Convert.ToDateTime(var).ToString("MM/dd/yyyy");
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = "";
                    }
                }
                else if (type == typeof(double))
                {
                    if (Convert.IsDBNull(var))
                    {
                        var = 0;
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = 0;
                    }
                }
                else if (type == typeof(decimal))
                {
                    if (Convert.IsDBNull(var))
                    {
                        var = 0;
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = 0;
                    }
                }
                else if (type == typeof(bool))
                {
                    if (Convert.IsDBNull(var))
                    {
                        var = false;
                    }
                    if (string.IsNullOrEmpty(var.ToString()))
                    {
                        var = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
            }
            return var;
        }
    }
}
