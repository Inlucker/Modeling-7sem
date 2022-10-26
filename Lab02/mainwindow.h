#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

#include <QLineSeries>
#include <QValueAxis>
#include <QChart>
#include <QChartView>
#include <QSpinBox>
#include <QSizePolicy>
#include <QLabel>
#include <QXYSeries>
#include <QMessageBox>

#include <math.h>
#include <iostream>

#include "Model.h"
using namespace std;

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
  Q_OBJECT

public:
  MainWindow(QWidget *parent = nullptr);
  ~MainWindow();

  void renderModel();

private:
  void selectPoint(int x, QLineSeries* series, QHash<QXYSeries::PointConfiguration, QVariant>& conf);

private slots:
  void on_pushButton_clicked();

private:
  Ui::MainWindow *ui;
  Model m;
  //QChart* chart = nullptr;
  QChartView *chart_view;
  QDoubleSpinBox edit_mtrx[MAX_N][MAX_N];
  QLabel p_mas[MAX_N];
  QLabel t_mas[MAX_N];
};
#endif // MAINWINDOW_H
