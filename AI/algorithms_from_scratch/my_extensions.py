from importlib.metadata import requires

import matplotlib.pyplot as plt
from abc import ABC, abstractmethod


class MyModelBase(ABC):
    @abstractmethod
    def show_parameters(self):
        ...

    @abstractmethod
    def show_loss_curve(self):
        ...

    @abstractmethod
    def fit(self, X, y):
        ...

    @abstractmethod
    def predict(self, X):
        ...


class MyRegressionBase(MyModelBase):
    """
    This class is a collection of methods that can be used to extend the functionality of the models.
    Used in Regression models.
    """

    def __init__(self):
        """
        Initialize the class.
        """

        # parameters/thetas learned by the model.
        # Needs to be initialized in a given model with random values.
        # The number of parameters/thetas is equal to the number of features + 1 for regression models.
        self.thetas = []

        # Here you can append the loss of each iteration of the fit method.
        # Later you can access this to visualize the loss curve during time.
        self.losses = []

    def show_parameters(self):
        """
        Show the parameters/thetas learned by the model.
        :return: List of thetas
        """
        return self.thetas

    def show_loss_curve(self):
        """
        Show the loss curve. Call this method after the fit method to see the full history of the loss.
        :return: None
        """
        plt.plot(self.losses)
        plt.xlabel('Iterations')
        plt.ylabel('Loss')
        plt.show()

    def fit(self, X, y):
        ...

    def predict(self, X):
        ...


class MySVMBase(MyModelBase):
    """
    This class is a collection of methods that can be used to extend the functionality of the models.
    Used in Support Vector Machines.
    """

    def __init__(self):
        """
        Initialize the class.
        """

        # parameters learned by the model.
        self.coef_ = None
        self.intercept_ = None
        self.support_vectors_ = None

        # Here you can append the loss of each iteration of the fit method.
        # Later you can access this to visualize the loss curve during time.
        self.Js = []

    def show_parameters(self):
        """
        Show the parameters/thetas learned by the model.
        :return: List of thetas
        """

        return f"coef_:\n{self.coef_}\n\nintercept_:\n{self.intercept_}\n\nsupport_vectors_:\n{self.support_vectors_}"

    def show_loss_curve(self):
        """
        Show the loss curve. Call this method after the fit method to see the full history of the loss.
        :return: None
        """
        plt.plot(self.Js)
        plt.xlabel('Iterations')
        plt.ylabel('Loss')
        plt.show()

    def fit(self, X, y):
        ...

    def predict(self, X):
        ...
