#ifndef DLLINTERFACE_H
#define DLLINTERFACE_H

#include "Model.h"

s21::Model _model = s21::Model();
std::vector<double> x;
std::vector<double> y;

extern "C" __attribute__ ((visibility ("default")))
const char* CalculateWrapper(const char* expression);

extern "C" __attribute__ ((visibility ("default")))
void GetGraphWrapper(const char* expression, double leftBound, double rightBound);

extern "C" __attribute__ ((visibility ("default")))
double* GetXArrayWrapper();

extern "C" __attribute__ ((visibility ("default")))
double* GetYArrayWrapper();

extern "C" __attribute__ ((visibility ("default")))
void FreeArrayMemoryWrapper(double* ptr);

#endif  // DLLINTERFACE_H