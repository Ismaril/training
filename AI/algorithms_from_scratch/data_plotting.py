import matplotlib.pyplot as plt
import numpy as np
from sklearn.base import BaseEstimator
from my_extensions import MyModelExtensions


class Plots:
    def __init__(self):
        ...

    def plot_decision_boundary(self,
                               model: MyModelExtensions | object,
                               X,
                               y,
                               bound_smoot=100,
                               fig_size=(16, 9),
                               grid=True,
                               verbose=False,
                               cmap="brg"):
        """
        :param model: model that's going to predict y from X
        :param X: features
        :param y: labels
        :param bound_smoot: smoothness of decision boundary, higher number higher smoothness
        :param fig_size: size of figure, enter two value tuple
        :param grid: if True place grid on plot
        :param verbose: print examples how internal data look like
        :param cmap: colormap from matplotlib
        """
        model.fit(X, y)

        # How it works in my words:
        #

        # Define the axis boundaries of the plot and create a meshgrid
        # set minimum and maximum for x and y axes on the plot
        # Xx, Xy will be grid of bound_smoot*bound_smoot. Resulting y_pred
        #   will have all labels in 2d matrix of this shape.
        x_min, x_max = X[:, 0].min(), X[:, 0].max()
        y_min, y_max = X[:, 1].min(), X[:, 1].max()
        Xx, Xy = np.meshgrid(np.linspace(x_min, x_max, bound_smoot),
                             np.linspace(y_min, y_max, bound_smoot))

        # Create X values (we're going to predict on all of these)
        # np.c_ makes columns from data inside its square brackets
        # ravel flattens multidimensional array
        X_in = np.c_[Xx.ravel(), Xy.ravel()]

        # Make predictions using the trained model on "grid of X values" and predict
        #   y labels. X_in (created by np.linspace) has equally separated values
        #   that create a grid across the whole plot that you gonna see, therefore
        #   there will be number of prediction equal to the number of points of grid
        #   of X_in. Therefore if we gonna predict y_labels on all grid values of X_in
        #   we gonna see that underlying colors (based on predicted labels) will be
        #   extending everywhere to the point where the prediction is another label. This
        #   means that the decision boundaries on the plot are real and predictions of
        #   hypothetical points on either on side or others should really label the feature (X)
        #   as different class
        y_pred = model.predict(X_in)
        y_pred = y_pred.reshape(Xx.shape)

        plt.figure(figsize=fig_size)
        plt.grid(grid)

        # Plot decision boundary
        plt.contourf(Xx,  # x coordinates of features
                     Xy,  # y coordinates of features
                     y_pred,  # labels of features
                     cmap=cmap,
                     alpha=0.5)  # set how dark should underling color be

        # plot points
        plt.scatter(X[:, 0],
                    X[:, 1],
                    c=y,
                    s=40,
                    cmap=cmap,
                    edgecolors="k")
        plt.show()

        if verbose:
            print("xx, yy, x_in, y_pred")
            print(Xx.shape, Xy.shape, X_in.shape, y_pred.shape, sep="\n" * 2)
            print(Xx[0], Xy[0], X_in[0], y_pred[0], sep="\n" * 2)
