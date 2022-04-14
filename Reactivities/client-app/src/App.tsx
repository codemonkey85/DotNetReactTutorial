import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from "axios";
// import { Header, List } from "semantic-ui-react";

function App() {
  const [activities, setActivities] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:7147/api/activities")
      .then((response) => setActivities(response.data));
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <h1>Hello world</h1>
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>{activity.title}</li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
