import React, { Component } from "react";
import "../styles/map.scss";

class AdminMapPanel extends Component {
  constructor(props) {
    super(props);
    this.changeVisualization = this.changeVisualization.bind(this);
    this.state = {
      visualtion: "grid",
    };
  }

  changeVisualization = (button) => {
    this.setState({
      visualtion: button,
    });
  };

  render() {
    return (
      <div className="wrapper-map">
        <div className="wrapper-visualization">
          <div className="visualization">
            <button
              className={
                "select-btn " +
                (this.state.visualtion === "map" ? "active" : "")
              }
              onClick={() => this.changeVisualization("map")}
            >
              Map
            </button>
            <button
              className={
                "select-btn " +
                (this.state.visualtion === "grid" ? "active" : "")
              }
              onClick={() => this.changeVisualization("grid")}
            >
              Grid
            </button>
          </div>
        </div>
      </div>
    );
  }
}

export default AdminMapPanel;
