#include "Model.h"

Model::Model(int _n, bool same)
{
  n = _n;
  for (int i = 0; i < MAX_N; i++)
  {
    for (int j = 0; j < MAX_N; j++)
      lambda_mtrx[i][j] = 0;
    time_mas[i] = 0;
    prob_mas[i] = 0;
  }
  if (!same)
    prob_mas[0] = 1;
  else
    for (int i = 0; i < n; i++)
      prob_mas[i] = 1.0/n;
}

bool Model::step(double dt)
{
  double newP[MAX_N];
  for (int i = 0; i < n; i++)
  {
    newP[i] = prob_mas[i];
    for (int j = 0; j < n; j++)
    {
      if (i == j) continue;
      newP[i] += dt * (prob_mas[j] * lambda_mtrx[j][i] - prob_mas[i] * lambda_mtrx[i][j]);
    }
  }

  bool isSt = isStable();

  for (int i = 0; i < MAX_N; i++)
    prob_mas[i] = newP[i];

  SetStableT();
  T += dt;
  return isSt;
}

bool Model::isStable()
{
  double res[MAX_N];
  Kolmogorov(res);
  for (int i = 0; i < n; i++)
    if (fabs(res[i]) > EPS/10)
      return false;
  return true;
}

void Model::Kolmogorov(double res[MAX_N])
{
  for (int i = 0; i < n; i++)
  {
    res[i] = 0;
    for (int j = 0; j < n; j++)
    {
      if (i == j) continue;
      res[i] += prob_mas[j] * lambda_mtrx[j][i] - prob_mas[i] * lambda_mtrx[i][j];
    }
  }
}

void Model::SetStableT()
{
  double kArr[MAX_N];
  Kolmogorov(kArr);
  for (int i = 0; i < n; i++)
  {
      if (fabs(kArr[i]) < EPS*100 && time_mas[i] <= EPS)
          time_mas[i] = T;
      else if (fabs(kArr[i]) > EPS*100 && time_mas[i] > EPS)
          time_mas[i] = 0;
  }
}
