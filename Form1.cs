namespace SeleniumDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ha sokszor futtatod fejlesztés közben lehet érdemes alapértéknek beírni a felhasználónevet és jelszót
            textBox1.Text = "lusta";
            textBox2.Text = "vagyok";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Az asztal elérési útja (vagy ahova szeretnéd az excelt), ha ügyes vagy csinálhaszt tallózás gombot is
            string desktopPath = @"\\Mac\Home\Desktop";
            //Példányosítjuk az excelt generáló Excelizer osztályunkat és a konstruktorának odaadjuk azt, ahova szeretnénk a fájlt.
            Excelizer excelizer = new Excelizer(desktopPath);

            //A classes listába belerakjuk az órarendi órákat, amit a Scraper osztály ScrapeClasses függvénye szerez meg a Neptunról, érdemes megfigyelni, hogy ezt közvetlenül az osztály neve után hívtuk, mert static!
            List<UniClass> classes=Scraper.ScrapeClasses(textBox1.Text,textBox2.Text);

            //Meghívjuk az excelizer példány Órarendkészítő metódusát, és odaadjuk a lekapart osztályokat
            excelizer.CreateTimeTable(classes);

            MessageBox.Show("Órarend legenerálva!");
        }
    }
}