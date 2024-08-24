import matplotlib.pyplot as plt
from abc import ABC, abstractmethod
import numpy as np


class MyModelBase(ABC):

    def __init__(self):
        # losses
        self.Js = []

        # learning rate parameters
        self.eta0 = 1
        self.eta_d = 1000

    @abstractmethod
    def show_parameters(self):
        ...

    @abstractmethod
    def fit(self, X, y):
        ...

    @abstractmethod
    def predict(self, X):
        ...

    def eta(self, epoch):
        """
        This function calculates the learning rate at each epoch.
        The greater the epoch, the smaller the learning rate.

        :param epoch: Number of an epoch in the training process
        :returns: Learning rate
        """
        return self.eta0 / (epoch + self.eta_d)

    def show_loss_curve(self):
        """
        Show the loss curve. Call this method after the fit method to see the full history of the loss.
        :return: None
        """
        # TODO: Fix this.
        try:
            plt.plot(self.Js)
        except AttributeError:
            plt.plot(self.losses)
        plt.xlabel('Iterations')
        plt.ylabel('Loss')
        plt.show()

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

    def fit(self, X, y):
        ...

    def predict(self, X):
        ...


class MySupportVectorClassiferBase(MyModelBase):
    """
    This class is a collection of methods that can be used to extend the functionality of the models.
    Used in Support Vector Machines.
    Note that support vector models can be used only for binary classification. For multiclass classification,
    you need to use certain techniques, like training one class vs all other classes and so on...
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

    @staticmethod
    def transform_datapoints_to_positive_and_negative(X, y):
        """
        This function converts the original y data to column vector and then -1 and 1 from False and True
        (meaning 0 and 1, because the False is 0 and True is 1)
        and multiplies the feature dataset with the converted y data.

        Example (Data do not make sense, important is the conversion):
        X = np.array([[1, 2], [3, 4], [5, 6]])
        y = [True, False, True]
        t = np.array(y, dtype=np.float64).reshape(-1, 1) * 2 - 1
        X_t = X * t
        X_t, t

        Result:
        (array([[ 1.,  2.],
                [-3., -4.],
                [ 5.,  6.]]),
         array([[ 1.],
                [-1.],
                [ 1.]]))

        :param X: Feature dataset
        :param y: Labels
        :returns: Converted feature dataset and labels
        """
        t = np.array(y, dtype=np.float64).reshape(-1, 1) * 2 - 1
        X_t = X * t
        return X_t, t

    @staticmethod
    def select_margin_violators(X_t, t, intercept, coef):
        """
        This function selects the margin violators.

        :param X_t: Feature dataset, which in this case is original dataset multiplied by -1 and 1.
        :param t: Labels, which are either -1 or 1.
        :param intercept: Intercept
        :param coef: Coefficients

        Returns:

        """
        support_vectors_idx = (X_t.dot(coef) + t * intercept < 1).ravel()
        X_t_sv = X_t[support_vectors_idx]
        t_sv = t[support_vectors_idx]

        return X_t_sv, t_sv, support_vectors_idx

    def show_parameters(self):
        """
        Show the parameters and support vectors learned by the model.
        :return: Parameters and support vectors separated by new line.
        """

        return f"coef_:\n{self.coef_}\n\nintercept_:\n{self.intercept_}\n\nsupport_vectors_:\n{self.support_vectors_}"

    def fit(self, X, y):
        ...

    def predict(self, X):
        ...


class MySupportVectorRegressionBase(MyModelBase):
    ...