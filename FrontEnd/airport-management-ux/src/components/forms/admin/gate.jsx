import React, { Component } from "react";
import SideBar from "./../../common/sidebar";
import NavBar from "./../../common/navbar";

class Gate extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <NavBar />
        <SideBar />
        <button>
          <a href="/admin/add-gate">Add Gate</a>
        </button>
      </React.Fragment>
    );
  }
}

export default Gate;
