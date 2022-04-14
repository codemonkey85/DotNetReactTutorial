import React from "react";
import { Button, Card } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activity: Activity;
}

export default function ActivityDetails({ activity }: Props) {
  return (
    <>
      <Card>
        <Card.Img
          variant="top"
          src={`./assets/categoryImages/${activity?.category}.jpg`}
          className="category-image"
        />
        <Card.Body>
          <Card.Title>{activity?.title}</Card.Title>
          <Card.Text>{activity?.description}</Card.Text>
          <Button variant="primary">Edit</Button>
          <Button variant="secondary">Cancel</Button>
        </Card.Body>
      </Card>
    </>
  );
}
