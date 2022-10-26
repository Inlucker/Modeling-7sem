#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
  : QMainWindow(parent)
  , ui(new Ui::MainWindow)
  , m(Model(3))
{
  ui->setupUi(this);

  ui->horizontalLayout_3->setStretch(0, 1);
  ui->horizontalLayout_3->setStretch(1, 3);
  ui->horizontalLayout_3->setStretch(2, 3);

  ui->splitter->setSizes(QList<int>({INT_MAX, INT_MAX}));;

  chart_view = new QChartView(this);
  ui->horizontalLayout->addWidget(chart_view);
  ui->verticalLayout->setStretch(0, 10);
  ui->verticalLayout->setStretch(1, 1);

  //chart = new QChart();
  //chart_view->setChart(chart);

  ui->gridLayout->setContentsMargins(0, 0, 0, 0);
  ui->gridLayout->setSpacing(2);
  ui->gridLayout->addWidget(new QLabel(""), 0, 0);
  ui->gridLayout->setColumnStretch(0, 1);
  for (int i = 1; i < MAX_N+1; i++)
  {
    ui->gridLayout->setColumnStretch(i, 1);
    QLabel *label = new QLabel(QString::number(i));
    label->setFont(QFont("calibri", 14));
    label->setAlignment(Qt::AlignCenter);
    ui->gridLayout->addWidget(label, 0, i);
  }
  for (int i = 1; i < MAX_N+1; i++)
  {
    QLabel *label = new QLabel(QString::number(i));
    label->setFont(QFont("calibri", 14));
    label->setAlignment(Qt::AlignCenter);
    ui->gridLayout->addWidget(label, i, 0);
  }

  for (int i = 0; i < MAX_N; i++)
  {
    for (int j = 0; j < MAX_N; j++)
    {
      edit_mtrx[i][j].setButtonSymbols(QAbstractSpinBox::NoButtons);
      edit_mtrx[i][j].setDecimals(1);
      ui->gridLayout->addWidget(&edit_mtrx[i][j], i+1, j+1);
      edit_mtrx[i][j].setSizePolicy(QSizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred));
      edit_mtrx[i][j].setMinimumSize(1, 1);
    }
  }

  QLabel *label_P = new QLabel("P");
  label_P->setFont(QFont("calibri", 14));
  label_P->setAlignment(Qt::AlignCenter);
  ui->gridLayout->addWidget(label_P, MAX_N+1, 0);
  for (int i = 0; i < MAX_N; i++)
  {
    p_mas[i].setStyleSheet("QLabel {"
                           "border-style: solid;"
                           "border-width: 1px;"
                           "border-color: black; "
                           "}");
    p_mas[i].setText("");
    p_mas[i].setFont(QFont("calibri", 14));
    p_mas[i].setAlignment(Qt::AlignCenter);
    ui->gridLayout->addWidget(&p_mas[i], MAX_N+1, i+1);
  }

  QLabel *label_T = new QLabel("T");
  label_T->setFont(QFont("calibri", 14));
  label_T->setAlignment(Qt::AlignCenter);
  ui->gridLayout->addWidget(label_T, MAX_N+2, 0);
  for (int i = 0; i < MAX_N; i++)
  {
    t_mas[i].setStyleSheet("QLabel {"
                           "border-style: solid;"
                           "border-width: 1px;"
                           "border-color: black; "
                           "}");
    t_mas[i].setText("");
    t_mas[i].setFont(QFont("calibri", 14));
    t_mas[i].setAlignment(Qt::AlignCenter);
    ui->gridLayout->addWidget(&t_mas[i], MAX_N+2, i+1);
  }

  edit_mtrx[0][1].setValue(0.1);
  edit_mtrx[1][2].setValue(0.2);
  edit_mtrx[2][0].setValue(0.3);
  m.lambda_mtrx[0][1] = 0.1;
  m.lambda_mtrx[1][2] = 0.2;
  m.lambda_mtrx[2][0] = 0.3;

  renderModel();
}

MainWindow::~MainWindow()
{
  //delete chart_view;
  //delete chart;
  delete ui;
}

void MainWindow::renderModel()
{
  if (chart_view->chart())
    chart_view->chart()->deleteLater();
  QChart* chart = new QChart();

  QLineSeries *series[m.n];
  for (int i = 0; i < m.n; i++)
    series[i] = new QLineSeries();
  //QLineSeries *series = new QLineSeries[m.n];
  while (!m.step(0.01))
    for (int i = 0; i < m.n; i++)
    {
      series[i]->append(m.T, m.prob_mas[i]);
      series[i]->setName(QString::number(i+1));
    }

  for (int i = 0; i < m.n; i++)
    chart->addSeries(series[i]);

  chart->legend()->setAlignment(Qt::AlignBottom);

  // Настройка осей графика
  chart->createDefaultAxes();
  chart->axes(Qt::Vertical).back()->setRange(0, 1);
  chart->axes(Qt::Vertical).back()->setTitleText("Probability");
  chart->axes(Qt::Horizontal).back()->setTitleText("Time");

  //Выделение точек
  QHash<QXYSeries::PointConfiguration, QVariant> conf;
  conf[QXYSeries::PointConfiguration::Color] = QColor(Qt::red);
  conf[QXYSeries::PointConfiguration::Size] = 4;
  conf[QXYSeries::PointConfiguration::Visibility] = true;

  for (int i = 0; i < MAX_N; i++)
  {
    p_mas[i].setText("");
    t_mas[i].setText("");
  }

  for (int i = 0; i < m.n; i++)
  {
    selectPoint(m.time_mas[i], series[i], conf);

    p_mas[i].setText(QString::number(round(m.prob_mas[i]*1000)/1000));
    t_mas[i].setText(QString::number(round(m.time_mas[i]*100)/100));
  }

  // Устанавливаем график в представление
  chart_view->setChart(chart);

  update();
}

void MainWindow::selectPoint(int x, QLineSeries *series, QHash<QXYSeries::PointConfiguration, QVariant>& conf)
{
  QList<QPointF> points = series->points();
  int len = points.size();
  int index = 0;
  for (int i = 0; i < len; i++)
    if (points[i].x() >= x)
    {
      index = i;
      break;
    }

  series->setPointConfiguration(index, conf);
}


void MainWindow::on_pushButton_clicked()
{
  m = Model(ui->spinBox->value(), ui->checkBox->isChecked());
  for (int i = 0; i < MAX_N; i++)
    for (int j = 0; j < MAX_N; j++)
    {
      if (i == j)
        continue;
      else
      {
        m.lambda_mtrx[i][j] = edit_mtrx[i][j].value();
        if (m.lambda_mtrx[i][j])
          m.lambda_mtrx[i][j] -= edit_mtrx[i][i].value();
      }
      if (m.lambda_mtrx[i][j] < 0)
      {
        QMessageBox::information(this, "Error", "Wrong input");
        return;
      }
    }

  renderModel();
}

