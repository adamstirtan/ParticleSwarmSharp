using System.Drawing.Imaging;

using ParticleSwarmSharp.Events;
using ParticleSwarmSharp.Fitness;
using ParticleSwarmSharp.Particles;
using ParticleSwarmSharp.Populations;
using ParticleSwarmSharp.Termination;

namespace ParticleSwarmSharp.Runner.ImageCopy
{
    public partial class Form1 : Form
    {
        private readonly int _polygonCount = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            int populationSize = 25;
            int rgba = 4;
            int points = 3;
            int dimensions = _polygonCount * ((points * 2) + rgba);

            var particles = new List<IParticle>();

            for (int i = 0; i < populationSize; i++)
            {
                particles.Add(new ImageCopyParticle(dimensions, pictureCopy.Width));
            }

            IParticleSwarm pso = new ParticleSwarm(
                new Population(particles),
                new FuncFitness(RedGreenBlueFitness),
                new GenerationCountTermination(1000));

            pso.BestParticleChanged += (s, e) =>
            {
                var @event = (BestParticleChangedEventArgs)e;

                Image copy = ToImage(@event.BestParticle);
                pictureCopy.Image = copy;

                lblBestFitness.Text = $"{@event.BestParticle.Fitness}{Environment.NewLine}";

                Application.DoEvents();
            };

            buttonChangeImage.Enabled = false;
            buttonCopy.Enabled = false;

            pso.Start();
        }

        private double RedGreenBlueFitness(IParticle particle)
        {
            double fitness = 0;

            Bitmap original = new(pictureOriginal.Image);
            Bitmap copy = ToImage(particle);

            using BmpPixelSnoop originalSnoop = new(original);
            using BmpPixelSnoop copySnoop = new(copy);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color copyColor = copySnoop.GetPixel(x, y);
                    Color originalColor = originalSnoop.GetPixel(x, y);

                    fitness += Math.Abs(copyColor.R - originalColor.R);
                    fitness += Math.Abs(copyColor.G - originalColor.G);
                    fitness += Math.Abs(copyColor.B - originalColor.B);
                }
            }

            return fitness;
        }

        private Bitmap ToImage(IParticle particle)
        {
            Bitmap image = new(pictureCopy.Width, pictureCopy.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);

            graphics.Clear(Color.White);

            for (int i = 0; i < _polygonCount; i += 10)
            {
                int r = Math.Clamp((int)particle.Position[i + 0], 0, 255);
                int g = Math.Clamp((int)particle.Position[i + 1], 0, 255);
                int b = Math.Clamp((int)particle.Position[i + 2], 0, 255);
                int a = Math.Clamp((int)particle.Position[i + 3], 0, 255);

                Point p1 = new((int)particle.Position[i + 4], (int)particle.Position[i + 5]);
                Point p2 = new((int)particle.Position[i + 6], (int)particle.Position[i + 7]);
                Point p3 = new((int)particle.Position[i + 8], (int)particle.Position[i + 9]);

                Brush brush = new SolidBrush(Color.FromArgb(a, r, g, b));

                graphics.FillPolygon(brush, new Point[] { p1, p2, p3 });
            }

            return image;
        }
    }
}