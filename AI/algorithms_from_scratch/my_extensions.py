import matplotlib.pyplot as plt

class MyModelExtensions:
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