import React from "react";

interface Props {
  inverted?: boolean;
  content?: string;
}

export default function LoadingComponent({
  inverted = true,
  content = "Loading...",
}: Props) {
  return (
    <div className={`loading-components ${inverted ? "inverted" : ""}`}>
      <div className="loading-components-content">{content}</div>
    </div>
  );
}
