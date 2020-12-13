import React, { Component } from "react";
import SideBar from "./../../common/sidebar";
import NavBar from "./../../common/navbar";

class Flight extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <NavBar />
        <SideBar />
        <button>
          <a href="/admin/add-flight">Add flights</a>
        </button>
      </React.Fragment>
    );
  }
}

export default Flight;
