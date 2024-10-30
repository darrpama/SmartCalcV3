#include "DllInterface.h"

extern "C" __attribute__ ((visibility ("default")))
const char* CalculateWrapper(const char* expression)
{
    std::string expr = expression;
    std::string answer = _model.CalculateExpression(expr);
    char* c_answer = new char[answer.size() + 1];
    std::strcpy(c_answer, answer.c_str());
    return c_answer;
}

extern "C" __attribute__ ((visibility ("default")))
void GetGraphWrapper(const char* expression, double leftBound, double rightBound)
{
    std::string expr = expression;
    std::pair<std::vector<double>, std::vector<double>> answer = _model.GetGraph(expr, leftBound, rightBound);
    x = answer.first;
    y = answer.second;
}

extern "C" __attribute__ ((visibility ("default")))
double* GetXArrayWrapper()
{
    double* result = new double[x.size()];
    std::copy(x.begin(), x.end(), result);
    return result;
}

extern "C" __attribute__ ((visibility ("default")))
double* GetYArrayWrapper()
{
    double* result = new double[y.size()];
    std::copy(y.begin(), y.end(), result);
    return result;
}

extern "C" __attribute__ ((visibility ("default")))
void FreeArrayMemoryWrapper(double* ptr)
{
    delete[] ptr;
}