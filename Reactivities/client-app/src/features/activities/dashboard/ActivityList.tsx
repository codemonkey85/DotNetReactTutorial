import React from "react";
import { Button, ListGroup } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activities: Activity[];
}

export default function ActivityList({ activities }: Props) {
  return (
    <>
      <ListGroup>
        {activities.map((activity) => (
          <ListGroup.Item key={activity.id} action href={`#${activity.id}`}>
            {activity?.title}
            <span>{activity?.date?.toString()}</span>
            <span>{activity?.description}</span>
            <span>{activity?.city}</span>
            <span>{activity?.venue}</span>
            <Button className="view-button">View</Button>
            <label>{activity?.category}</label>
          </ListGroup.Item>
        ))}
      </ListGroup>
    </>
  );
}
