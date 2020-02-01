import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import NavBar from "./components/common/navbar";
import NavBarAdmin from "./components/common/navbarAdmin";
import Home from "./components/home";

import Login from "./components/forms/login";

import Airports from "./components/forms/admin/airports";
import Aircraft from "./components/forms/admin/aircraft";
import Destination from "./components/forms/admin/destination";
import Flight from "./components/forms/admin/flight";
import Terminal from "./components/forms/admin/terminal";
import Gate from "./components/forms/admin/gate";

//
import AddAircraft from "./components/forms/admin/Add/AddAircraft";
import AddAirport from "./components/forms/admin/Add/AddAirport";
import AddDestination from "./components/forms/admin/Add/AddDestination";
import AddFlight from "./components/forms/admin/Add/AddFlight";
import AddGate from "./components/forms/admin/Add/AddGate";
import AddTerminal from "./components/forms/admin/Add/AddTerminal";

import CabinCrew from "./components/forms/cabinCrew";

import "../src/styles/app.scss";

class App extends Component {
  state = {};
  render() {
    return (
      <div className="wrapper">
        <NavBarAdmin />
        <div className="content">
          <Switch>
            <Route path="/admin/destination" component={Destination} />
            <Route path="/admin/add-airport/:id" component={AddAirport} />
            <Route path="/admin/airports" component={Airports} />
            <Route path="/admin/aircraft" component={Aircraft} />
            <Route path="/admin/terminal" component={Terminal} />
            <Route path="/admin/gate" component={Gate} />
            <Route path="/admin/flight" component={Flight} />

            <Route path="/admin/add-flight" component={AddFlight} />
            <Route path="/admin/add-aircraft" component={AddAircraft} />
            <Route path="/admin/add-airport" component={AddAirport} />
            <Route path="/admin/add-destination" component={AddDestination} />
            <Route path="/admin/add-flight" component={AddFlight} />
            <Route path="/admin/add-gate" component={AddGate} />
            <Route path="/admin/add-terminal" component={AddTerminal} />

            <Route path="/cabin-crew" component={CabinCrew} />
            <Route path="/login" component={Login} />
            <Route path="/" component={Home} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;
