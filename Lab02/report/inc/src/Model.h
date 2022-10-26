#ifndef MODEL_H
#define MODEL_H

#include "math.h"

#define MAX_N 10
#define EPS 1e-8

class Model
{
public:
  Model(int _n, bool same = false);

  bool step(double dt);

private:
  bool isStable();
  void Kolmogorov(double res[MAX_N]);
  void SetStableT();

public:
  double prob_mas[MAX_N];
  double time_mas[MAX_N];
  double lambda_mtrx[MAX_N][MAX_N];
  int n = 0;
  double T = 0;
};

#endif // MODEL_H
