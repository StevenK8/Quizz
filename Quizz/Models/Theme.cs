namespace QuizzNoGood.Models
{
    public class Theme
    {

        public int Id { get; set; }
        private string _themeName;
        public string ThemeName
        {
            get => _themeName;
            private set
            {
                _themeName = value;
            }
        }

        /// <summary>
        /// Create a Theme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="themeName"></param>
        public Theme(int id, string themeName)
        {
            Id = id;
            Username = username;
        }
        
        /// <summary>
        /// Create a Theme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="themeName"></param>
        /// <returns></returns>
        public static Theme CreateNewTheme(int id, string themeName)
        {
            return new Theme(id, themeName);
        }
    }
}
