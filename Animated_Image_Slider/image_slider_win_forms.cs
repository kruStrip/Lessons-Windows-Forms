using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Animated_Image_Slider // замените на имя вашего проекта при необходимости
{
    /// <summary>
    /// Анимированный слайдер изображений для WinForms.
    /// Версия 3 – ещё более плавная анимация (кадр каждые 10 мс, переход 1,4 сек).
    /// </summary>
    public class ImageSliderForm : Form
    {
        private readonly List<Image> _images = new();
        private int _currentIndex;

        // ─── Параметры анимации ────────────────────────────────────────────────
        private const int Fps = 100;              // 100 Гц ≈ кадр / 10 мс
        private const float AnimationSeconds = 1.4f; // длительность перехода
        private const float MaxWindowFill = 0.8f; // максимальная доля окна, которую занимает картинка
        private const float ScaleAmplitude = 0.06f; // ±6 % лёгкого зум‑эффекта

        private readonly System.Windows.Forms.Timer _timer;
        private float _t; // 0…1 прогресс текущей анимации

        // ─── Конструктор ────────────────────────────────────────────────────────
        public ImageSliderForm()
        {
            Text = "Animated Image Slider";
            DoubleBuffered = true;
            BackColor = Color.Black;
            ClientSize = new Size(800, 600);

            // timer @ 100 fps
            _timer = new System.Windows.Forms.Timer { Interval = 1000 / Fps };
            _timer.Tick += (_, _) =>
            {
                _t += 1f / (Fps * AnimationSeconds);
                if (_t >= 1f)
                {
                    _t = 0f;
                    _currentIndex = (_currentIndex + 1) % _images.Count;
                }
                Invalidate();
            };

            LoadImages();
            if (_images.Count > 1) _timer.Start();
        }

        // ─── Загрузка файлов из папки images ───────────────────────────────────
        private void LoadImages()
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            if (!Directory.Exists(dir)) return;
            foreach (var file in Directory.GetFiles(dir))
            {
                try { _images.Add(Image.FromFile(file)); }
                catch { /* игнор повреждённых файлов */ }
            }
        }

        // ─── Функция плавности (cubic ease‑in‑out) ─────────────────────────────
        private static float Ease(float x) => x < .5f ? 4f * x * x * x : 1f - MathF.Pow(-2f * x + 2f, 3f) / 2f;

        // ─── Рисование кадра ───────────────────────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_images.Count == 0) return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            int next = (_currentIndex + 1) % _images.Count;
            float eased = Ease(_t);

            DrawSlide(g, _images[_currentIndex], 0f - eased);   // уходящий слева
            DrawSlide(g, _images[next], 1f - eased);            // приходящий справа
        }

        private void DrawSlide(Graphics g, Image img, float offset)
        {
            // базовый масштаб под размер окна
            float fit = MathF.Min(ClientSize.Width / (float)img.Width,
                                   ClientSize.Height / (float)img.Height) * MaxWindowFill;

            // лёгкий «дыхательный» масштаб (±ScaleAmplitude)
            float pulse = 1f + ScaleAmplitude * MathF.Sin(_t * MathF.PI);
            fit *= pulse;

            // центр изображения
            float x = ClientSize.Width / 2f + offset * ClientSize.Width;
            float y = ClientSize.Height / 2f;

            g.TranslateTransform(x, y);
            g.ScaleTransform(fit, fit);
            g.TranslateTransform(-img.Width / 2f, -img.Height / 2f);

            g.DrawImage(img, Point.Empty);

            g.ResetTransform();
        }

        // ─── Освобождение памяти ───────────────────────────────────────────────
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            foreach (var img in _images) img.Dispose();
            base.OnFormClosed(e);
        }
    }
}
