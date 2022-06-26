import matplotlib.pyplot as plt
import numpy as np


class Plots:
    @staticmethod
    def plot_decision_boundary(model,
                               X,
                               y,
                               expand=1,
                               bound_smoot=100,
                               fig_size=(16, 9),
                               grid=True,
                               verbose=False,
                               cmap="brg"):
        """
        :param model: model that's going to predict y from X
        :param X: features
        :param y: labels
        :param expand: expand x, y plot axis to have visible points on the borders more visible
        :param bound_smoot: smoothness of decision boundary, higher number higher smoothness
        :param fig_size: size of figure, enter two value tuple
        :param grid: if True place grid on plot
        :param verbose: print examples how internal data look like
        :param cmap: colormap from matplotlib
        """

        # Define the axis boundaries of the plot and create a meshgrid
        # set minimum and maximum for x and y axes on the plot
        x_min, x_max = X[:, 0].min(), X[:, 0].max()
        y_min, y_max = X[:, 1].min(), X[:, 1].max()
        xx, yy = np.meshgrid(np.linspace(x_min - expand, x_max + expand, bound_smoot),
                             np.linspace(y_min - expand, y_max + expand, bound_smoot))

        # Create X values (we're going to predict on all of these)
        # np.c_ makes columns from data inside its square brackets
        # ravel flattens multidimensional array
        x_in = np.c_[xx.ravel(), yy.ravel()]

        # Make predictions using the trained model
        y_pred = model.predict(x_in)

        # TODO: explain this row
        y_pred = np.round(y_pred).reshape(xx.shape)

        # Plot decision boundary
        plt.figure(figsize=fig_size)
        plt.grid(grid)
        plt.contourf(xx,
                     yy,
                     y_pred,
                     cmap=cmap,
                     alpha=0.7)

        plt.scatter(X[:, 0],
                    X[:, 1],
                    c=y, s=40,
                    cmap=cmap,
                    edgecolors="k")
        plt.show()

        if verbose:
            print("xx, yy, x_in, y_pred")
            print(xx.shape, yy.shape, x_in.shape, y_pred.shape, sep="\n" * 2)
            print(xx[0], yy[0], x_in[0], y_pred[0], sep="\n" * 2)
