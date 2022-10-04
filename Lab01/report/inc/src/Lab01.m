close all
clear
clc

% Равномерное распределение
a = 0;
b = 0;
while a >= b
    prompt = " Введите a: ";
    a = input(prompt);
    prompt = " Введите b: ";
    b = input(prompt);
end

% Функция распределения
pd = makedist('Uniform','lower',a,'upper',b);
tmp = (b-a)/2;
x = a-tmp:.01:b+tmp;
pdf = pdf(pd,x);

figure('Name','Функция равномерного распределения', ...
    'NumberTitle', 'off', ...
    'Position', [180 555 560 420]);
hold on;
plot(x, pdf, "blue");
grid;
legend('Распределение', 'Location', 'south');
hold off;

% Функция плотности
cdf = cdf(pd,x);

figure('Name','Функция плотности равномерного распределения', ...
    'NumberTitle', 'off', ...
    'Position', [740 555 560 420]);
hold on;
plot(x, cdf, "red");
grid;
legend('Плотность распределения', 'Location', 'southeast');
hold off;

% Гамма-распределение
alpha = 0;
lambda = 0;
while lambda <= 0 && alpha <= 0
    prompt = " Введите \alpha: ";
    alpha = input(prompt);
    prompt = " Введите \lambda: ";
    lambda = input(prompt);
end

% Функция распределения
gamma_x = 0:0.1:50;
gammapdf_y = gampdf(gamma_x, lambda, alpha);

figure('Name','Функция гамма распределения', ...
    'NumberTitle', 'off', ...
    'Position', [180 50 560 420]);
hold on;
plot(gamma_x, gammapdf_y, "blue");
grid;
legend('Распределение', 'Location', 'northeast');
hold off;

% Функция плотности
gammacdf_y = gamcdf(gamma_x, lambda, alpha);

figure('Name','Функция плотности гамма распределения', ...
    'NumberTitle', 'off', ...
    'Position', [740 50 560 420]);
hold on;
plot(gamma_x, gammacdf_y, "red");
grid;
legend('Плотность распределения', 'Location', 'southeast');
hold off;