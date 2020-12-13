import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";

import Login from "./components/forms/login";

import Airports from "./components/forms/admin/airports";
import Aircrafts from "./components/forms/admin/aircrafts";
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

import "../src/styles/app.scss";
import AdminPanel from "./components/forms/admin/admin-panel";
import AdminMapPanel from "./components/map";
import NotFound from "./pages/404";

class App extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <Switch>
          <Route exact path="/admin/add-airport/:id" component={AddAirport} />
          <Route exact path="/admin/add-aircraft/:id" component={AddAircraft} />
          
          <Route exact path="/admin/airports" component={Airports} />
          <Route exact path="/admin/aircrafts" component={Aircrafts} />
          <Route exact path="/admin/terminal" component={Terminal} />
          <Route exact path="/admin/gate" component={Gate} />
          <Route exact path="/admin/flight" component={Flight} />
          <Route exact path="/admin/destination" component={Destination} />

          <Route exact path="/admin/add-flight" component={AddFlight} />
          <Route exact path="/admin/add-aircraft" component={AddAircraft} />
          <Route exact path="/admin/add-airport" component={AddAirport} />
          <Route
            exact
            path="/admin/add-destination"
            component={AddDestination}
          />
          <Route exact path="/admin/add-flight" component={AddFlight} />
          <Route exact path="/admin/add-gate" component={AddGate} />
          <Route exact path="/admin/add-terminal" component={AddTerminal} />

          <Route exact path="/admin-panel" component={AdminPanel} />
          <Route exact path="/admin-map" component={AdminMapPanel} />
          <Route exact path="/" component={Login} />
          <Route component={NotFound} />
        </Switch>
      </React.Fragment>
    );
  }
}

export default App;
