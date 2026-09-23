workspace "FPT RAG Lab" "Outcome-Aligned Quiz Generation Platform for FPT University students." {

    model {

        // ─── Actors / People ───────────────────────────────────────────────────
        student = person "Student" "FPT University student who uploads course materials, configures and generates outcome-aligned MCQ quizzes, takes quizzes, and reviews results with source citations."

        administrator = person "Administrator" "System administrator who manages users, courses, learning outcomes, token quotas, system policies, and monitors platform usage."

        // ─── Primary Software System ───────────────────────────────────────────
        fptRagLab = softwareSystem "FPT RAG Lab" "An AI-assisted web platform that lets students generate Retrieval-Augmented Generation (RAG) based, outcome-aligned multiple-choice quizzes strictly from their uploaded course documents."

        // ─── External Software Systems ─────────────────────────────────────────
        llmApi = softwareSystem "LLM API" "Large Language Model API (e.g. OpenAI GPT / Google Gemini) used to generate quiz questions, answer options, explanations, and grounding validations from RAG context." "External"

        embeddingApi = softwareSystem "Embedding API" "Text embedding service (e.g. OpenAI Embeddings / open-source model) that converts document chunks and retrieval queries into vector representations for semantic search." "External"

        emailService = softwareSystem "Email Service" "Transactional email provider (e.g. SendGrid / SMTP) used to send account registration confirmations, password resets, and system notifications to users." "External"

        ocrService = softwareSystem "OCR Service" "Optical Character Recognition service used to extract text from scanned or image-based PDF documents before chunking and embedding." "External"

        // ─── Relationships ─────────────────────────────────────────────────────
        // Actors → Primary System
        student      -> fptRagLab "Uploads documents, generates and takes outcome-aligned quizzes, reviews results and citations" "HTTPS"
        administrator -> fptRagLab "Manages users, courses, learning outcomes, token quotas and system policies" "HTTPS"

        // Primary System → External Systems
        fptRagLab -> llmApi        "Sends RAG context + prompt constraints; receives generated questions, options, explanations and grounding validation" "REST/JSON"
        fptRagLab -> embeddingApi  "Sends document chunks and retrieval queries; receives vector embeddings for pgvector storage and semantic search" "REST/JSON"
        fptRagLab -> emailService  "Sends account verification and notification emails" "SMTP / REST"
        fptRagLab -> ocrService    "Sends scanned PDF pages; receives extracted plain text for chunking" "REST/JSON"
    }

    views {

        // ── C0: System Context Diagram ──────────────────────────────────────────
        systemContext fptRagLab "SystemContext" "System Context diagram (C0) for FPT RAG Lab – Outcome-Aligned Quiz Generation Platform" {
            include *
            autoLayout
        }

        // ── Styles ──────────────────────────────────────────────────────────────
        styles {
            element "Person" {
                shape Person
                background #08427B
                color #ffffff
                fontSize 14
            }
            element "Software System" {
                background #1168BD
                color #ffffff
                fontSize 14
            }
            element "External" {
                background #6B6B6B
                color #ffffff
                fontSize 13
            }
        }

        theme default
    }

}
