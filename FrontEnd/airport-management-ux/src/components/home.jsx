import React, { Component } from "react";
import "../styles/home.scss";

class Home extends Component {
  state = {
    airports: []
  };
  render() {
    return (
      <div>
        <div className="homeContainer"></div>
      </div>
    );
  }
}

export default Home;
